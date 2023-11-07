using DataAcess.Demo.Entities;
using DataAcess.Demo.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMyShopUnitOfWork _myShopUnitOfWork;
        public OrderController(IMyShopUnitOfWork myShopUnitOfWork)
        {
            _myShopUnitOfWork = myShopUnitOfWork;
        }

        [HttpPost("OrderInsert")]
       
        public async Task<ActionResult> ProductInsert(Order order)
        {

            try
            {

                //var result = await _productServices.ProductInsert(product);
                var result = await _myShopUnitOfWork._orderRepository.OrderInsert(order);

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
