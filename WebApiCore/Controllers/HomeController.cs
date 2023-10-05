using DataAcess.Demo.Entities;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Request.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IProductServices _productServices;

        public HomeController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        [HttpPost("ProductInsert")]
        public async Task<ActionResult> ProductInsert(Product product)
        {
            try
            {
                var result = await _productServices.ProductInsert(product);

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
                var requestData = new ProductGetListRequestData
                {
                    PrductID = id
                };
                var list = await _productServices.GetProducts(requestData);
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok();
        }

        [HttpPost("GetList")]
        public async Task<ActionResult> GetList(ProductGetListRequestData requestData)
        {
            // var list = new List<Product>();
            try
            {
                var list = await _productServices.GetProducts(requestData);
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok();
        }
    }
}
