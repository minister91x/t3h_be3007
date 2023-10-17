using DataAcess.Demo.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IFuncitonServices _functionservices;
        public MenuController(IFuncitonServices functionservices)
        {
            _functionservices = functionservices;
        }
        [HttpPost("GetList")]
        public async Task<ActionResult> GetList()
        {
            try
            {
                var lstFunction= await _functionservices.GetFunctions();
                return Ok(lstFunction);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
