using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiCore.LogServices;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogingController : ControllerBase
    {
        public ILogger<Student> _logger;
        private readonly ILoggerManager _loggerManager;

        public LogingController(ILogger<Student> logger, ILoggerManager loggerManager)
        {
            _logger = logger;
            _loggerManager = loggerManager;
        }

        [HttpPost("Index")]
        public IActionResult Index()
        {
            var logID = DateTime.Now.Ticks;
            var student = new Student("MrQuan", "BE_NET_CORE_0323", _logger);

            _loggerManager.LogInfo(logID + " | user:" + JsonConvert.SerializeObject(student));
            _loggerManager.LogDebug("Here is debug message from the controller.");
            _loggerManager.LogWarn("Here is warn message from the controller.");
            _loggerManager.LogError("Here is error message from the controller.");

            return Ok();
        }

    }
}
