using DataAcess.Demo.Entities;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Request.Product;
using DataAcess.Demo.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
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
        public HomeController(IMyShopUnitOfWork myShopUnitOfWork)
        {
            _myShopUnitOfWork = myShopUnitOfWork;
         // _loggerManager = loggerManager;
        }

        [HttpPost("ProductInsert")]
        [MyShopAuthorize("ABC", "DEFT")]
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
        // [MyShopAuthorize("HOTEL", "VIEW")]
        public async Task<ActionResult> GetList(ProductGetListRequestData requestData)
        {
            // var list = new List<Product>();
            try
            {
                var getcurrentUser = GetCurrentUser();
                if (getcurrentUser == null || string.IsNullOrEmpty(getcurrentUser.Email))
                {
                    return Ok(new { code = -1, messenger = "Vui lòng đăng nhâp" });
                }

                // check role 
                //var checkRole = await UserCheckRole(getcurrentUser.ID, "HOTEL", "VIEW");

                //if (!checkRole)
                //{
                //    return Ok(new { code = -1, messenger = "kHÔNG CÓ QUYỀN" });
                //}

                var list = await _myShopUnitOfWork.Products.GetProducts(requestData);
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok();
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
