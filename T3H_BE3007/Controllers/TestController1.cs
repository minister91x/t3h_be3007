using Microsoft.AspNetCore.Mvc;

namespace T3H_BE3007.Controllers
{
    public class TestController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
