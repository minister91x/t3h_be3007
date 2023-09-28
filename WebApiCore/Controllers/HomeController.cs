using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost("GetList")]
        public async Task<ActionResult> GetList()
        {
            var lsst = new List<string>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    lsst.Add("item:" + i);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok(lsst);
        }
    }
}
