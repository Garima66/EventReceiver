using Microsoft.AspNetCore.Mvc;

namespace EventReceiver.Controllers
{

    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public IActionResult Receive([FromBody] object data)
        {
            Console.WriteLine(data.ToString());
            return Ok();
        }
    }
}
