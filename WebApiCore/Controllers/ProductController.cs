using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IConfiguration _config;
        public ProductController(IConfiguration configtion)
        {
            _config = configtion;
        }

        [HttpPost("Uploadimage")]
        public async Task<ActionResult> UploadImage(UploadImageRequestData requestData)
        {
            var returnData = new UploadImageResponseData();
            try
            {

                var url_api = _config["MEDIA:URL"] ?? "http://localhost:5022/";
                var base_url = "Upload/UploadProductImage";

                var secretKey = _config["Sercurity:secretKeyEmployeer"] ?? "CAjEbwkeGqO@#Gn3Fsd8SRs2dFLMfxTo11a";
                var Sign = Compuer.Common.Security.MD5Hash(requestData.base64Image + "|" + secretKey);
                requestData.sign = Sign;

                var dataJson = JsonConvert.SerializeObject(requestData);

                //var token = Request.Cookies["TOKEN_SERVER"] != null ? Request.Cookies["TOKEN_SERVER"].Value : string.Empty;

                var result = Compuer.Common.HttpHelper.WebPost_WithToken(url_api, base_url, dataJson, "");

            }
            catch (Exception)
            {

                throw;
            }

            return Ok(returnData);
        }
    }
}
