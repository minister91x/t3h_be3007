using DataAcess.Demo.Entities;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Request.Product;
using DataAcess.Demo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public HomeController(IMyShopUnitOfWork myShopUnitOfWork)
        {
            _myShopUnitOfWork = myShopUnitOfWork;
        }

        [HttpPost("ProductInsert")]
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
                var requestData = new ProductGetListRequestData
                {
                    PrductID = id
                };
                //var list = await _productServices.GetProducts(requestData);
                var list = await _myShopUnitOfWork.Products.GetProducts(requestData);
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
                var list = await _myShopUnitOfWork.Products.GetProducts(requestData);
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
