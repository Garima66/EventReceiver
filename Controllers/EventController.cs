using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EventReceiver.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public IActionResult Receive([FromBody] JsonElement[] events)
        {
            var eventData = events[0];

            var eventType =
                eventData.GetProperty("eventType").GetString();

            if (eventType ==
                "Microsoft.EventGrid.SubscriptionValidationEvent")
            {
                var validationCode =
                    eventData.GetProperty("data")
                             .GetProperty("validationCode")
                             .GetString();

                return Ok(new
                {
                    validationResponse = validationCode
                });
            }

            Console.WriteLine(eventData.ToString());

            return Ok();
        }
    }
}