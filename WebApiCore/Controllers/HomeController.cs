using DataAcess.Demo.Entities;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Request.Product;
using DataAcess.Demo.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Security.Claims;
using System.Text;
using WebApiCore.BaseModel;
using WebApiCore.Filter;
using WebApiCore.LogServices;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //private IProductRepository _productServices;

        //public HomeController(IProductRepository productServices)
        //{
        //    _productServices = productServices;
        //}

        private IMyShopUnitOfWork _myShopUnitOfWork;
        //  private readonly ILoggerManager _loggerManager;
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;
        public HomeController(IMyShopUnitOfWork myShopUnitOfWork, IDistributedCache cache, IConfiguration configuration)
        {
            _myShopUnitOfWork = myShopUnitOfWork;
            // _loggerManager = loggerManager;
            _cache = cache;
            _configuration = configuration;

        }

        [HttpPost("ProductInsert")]
        [MyCustomAuthorize("PRODUCT_GETLIST", "INSERT")]
        public async Task<ActionResult> ProductInsert(Product product)
        {

            try
            {

                //var result = await _productServices.ProductInsert(product);
                var result = await _myShopUnitOfWork.Products.ProductInsert(product);

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("GetListByHttpGet")]

        public async Task<ActionResult> GetList(int id)
        {
            // var list = new List<Product>();
            try
            {
                //var getcurrentUser = GetCurrentUser();
                //if (getcurrentUser == null || string.IsNullOrEmpty(getcurrentUser.Email))
                //{
                //    return Ok(new { code = -1, messenger = "Vui lòng đăng nhâp" });
                //}

                var requestData = new ProductGetListRequestData
                {
                    PrductID = id
                };
                //var list = await _productServices.GetProducts(requestData);
                var list = await _myShopUnitOfWork.Products.GetProducts(requestData);

                //  _loggerManager.LogInfo("GetProducts:" + JsonConvert.SerializeObject(list));
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok();
        }

        [HttpPost("GetList")]
        // [MyCustomAuthorize("PRODUCT_GETLIST", "VIEW")]
        public async Task<ActionResult> GetList(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                //var getcurrentUser = GetCurrentUser();
                //if (getcurrentUser == null || string.IsNullOrEmpty(getcurrentUser.Email))
                //{
                //    return Ok(new { code = -1, messenger = "Vui lòng đăng nhâp" });
                //}

                // check role 
                //var checkRole = await UserCheckRole(getcurrentUser.ID, "HOTEL", "VIEW");

                //if (!checkRole)
                //{
                //    return Ok(new { code = -1, messenger = "kHÔNG CÓ QUYỀN" });
                //}
                var key_cache = "GET_LIST_PRODUCT_" + requestData.PrductID;
                var cacheValue = await _cache.GetAsync(key_cache);

                if (cacheValue != null)
                {
                    var cachedDataString = Encoding.UTF8.GetString(cacheValue);
                    if (cachedDataString != null)
                    {
                        list = JsonConvert.DeserializeObject<List<Product>>(cachedDataString.ToString());
                    }

                    return Ok(list);

                }


                // vào database để lấy dữ liệu
                list = await _myShopUnitOfWork.Products.GetProducts(requestData);
                if (list.Count > 0)
                {
                    // lưu cache 
                    var dataCache = JsonConvert.SerializeObject(list);

                    var dataToCache = Encoding.UTF8.GetBytes(dataCache);

                    DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                    await _cache.SetAsync(key_cache, dataToCache, options);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok();
        }

        [HttpPost("Import")]
        public async Task<int> Import([FromForm] UploadFileInputDto formFile)
        {
            var errItemStr = string.Empty;
            var errItemCount = 0;
            var successItemCount = 0;

            try
            {

                if (formFile == null || formFile.File.Length <= 0)
                {
                    throw new Exception("file dữ liệu không được trống");
                }

                if (!Path.GetExtension(formFile.File.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Hệ thống chỉ hỗ trợ file .xlsx");
                }

                using (var stream = new MemoryStream())
                {
                    await formFile.File.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.Commercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 3; row <= rowCount; row++)
                        {
                            var name = worksheet.Cells[row, 2]?.Value?.ToString()?.Trim();
                            var dongia = worksheet.Cells[row, 3]?.Value?.ToString()?.Trim();
                            var donvitinh = worksheet.Cells[row, 4]?.Value?.ToString()?.Trim();
                            var baohanh = worksheet.Cells[row, 5]?.Value?.ToString()?.Trim();

                            var product = new Product
                            {
                                PrductName = name,
                                DonViTinh = donvitinh,
                                DonGia = Convert.ToInt32(dongia)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return 1;
        }

        [HttpPost("Export")]
        public async Task<IActionResult> Export([FromBody] ProductGetListRequestData requestData)
        {
            var contentRoot = _configuration["TemplateEXCEL"] ?? "";
            var webRoot = Path.Combine(contentRoot, "Template");
            var templateFileInfo = new FileInfo(Path.Combine(contentRoot, "CheckDailyTemplate.xlsx"));
            var packageReport = await DesignWorkSheetExportAsync(requestData, templateFileInfo);

            return File(packageReport, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
        }


        private async Task<byte[]?> DesignWorkSheetExportAsync(ProductGetListRequestData requestData, FileInfo path)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (var package = new ExcelPackage(path))
            {
                //Tạo mới package execl
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");
                var list = await _myShopUnitOfWork.Products.GetProducts(requestData);


                worksheet.Cells["A1:Q1"].Merge = true;
                worksheet.Cells["A1:Q1"].Value = "Export";
                worksheet.Cells["A2"].Value = "PRODUCTNAME";
                int index = 3;
                int total = list.Count;
                int stt = 1;
                foreach (var item in list)
                {
                    int megerRow = index;
                    worksheet.Cells[index, 1, megerRow, 1].Merge = true;
                    worksheet.Cells[index, 2, megerRow, 2].Merge = true;

                    worksheet.Cells[$"A{index}"].Value = item.PrductName;
                    index++;
                    stt++;
                }

                package.Save();
                return package.GetAsByteArray();
            }
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    ID = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value),
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    FullName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                };

            }
            return null;
        }

        private async Task<bool> UserCheckRole(int UserId, string functionCode, string Role)
        {
            try
            {
                var funcionID = await _myShopUnitOfWork.funcitonServices.GetFunctionIDByCode(functionCode);

                var userFunction = await _myShopUnitOfWork.userFuncitonServices.GetUserFuntion(funcionID, UserId);
                if (Role == "VIEW")
                {
                    if (userFunction.IsView == 0) { return false; }
                }
                if (Role == "INSERT")
                {
                    if (userFunction.IsUpdate == 0) { return false; }
                }

                if (Role == "DELETE")
                {
                    if (userFunction.IsDelete == 0) { return false; }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
    }
}
