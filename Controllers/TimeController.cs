using Microsoft.AspNetCore.Mvc;

namespace MyWebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet("timenow")]
        public ActionResult<string> GetTimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        [HttpGet("raznica")]
        public ActionResult<string> GetTimeDifference([FromQuery] string time)
        {
            if (TimeSpan.TryParseExact(time, "c", null, System.Globalization.TimeSpanStyles.None, out var specifiedTime))
            {
                var currentTime = DateTime.Now.TimeOfDay;
                var difference = currentTime - specifiedTime;
                var formattedDifference = $"{Math.Abs(difference.Hours):00}:{Math.Abs(difference.Minutes):00}:{Math.Abs(difference.Seconds):00}";
                return Ok($"Разница времени: {formattedDifference}");
            }
            else
            {
                return BadRequest("Неверный формат HH:mm:ss.");
            }
        }
    }
}
