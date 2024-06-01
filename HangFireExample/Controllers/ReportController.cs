using Microsoft.AspNetCore.Mvc;

namespace HangFireExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpGet(Name = "GetReport")]
        public IActionResult GetReport()
        {
            Task.Delay(TimeSpan.FromMinutes(1));
            return Ok();
        }
    }
}
