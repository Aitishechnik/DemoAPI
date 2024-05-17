using DemoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using DemoAPI.Models;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredictionsController : ControllerBase
    {
        private readonly ILogger<PredictionsController> _logger;

        private readonly string[] ZodiacSigns = { "Овен: ", "Телец: ", "Близнецы: ", "Рак: ", "Лев: ", "Дева: ", "Весы: ", "Скорпион: ", "Стрелец: ", "Козерог: ", "Водолей: ", "Рыбы: " };
        private readonly string[] Periods = { "Всю неделю ", "Весь месяц ", "Весь год " };
        private readonly string[] Actions = {"катайтесь на самокате ", "сидите на мягких стульях ", "прыгайте по лужам ", "берите кредиты в больших количествах ", "управляйте авто с закрытыми глазами ", "пейте колу ", "стойте на одной ноге " };
        private readonly string[] Subjects = { "больше часа в день.", "возле свалки.", "не переживая за последствия.", "рядом с другими людьми."};
        private IExtraService ExtraSerivce;

        public PredictionsController(IExtraService extraService, ILogger<PredictionsController> logger)
        {
            ExtraSerivce = extraService;
            _logger = logger;
        }

        [HttpGet("GetPredition")]
        public IActionResult Get()
        {
            var random = new Random();
            List<Predictions> predictions = new List<Predictions>();

            foreach (var sign in ZodiacSigns)
            {
                predictions.Add(new Predictions(sign,
                    Periods[random.Next(Periods.Length)],
                    Actions[random.Next(Actions.Length)],
                    Subjects[random.Next(Subjects.Length)]));
                if (ExtraSerivce != null && ExtraSerivce.Extras.Count > 0)
                    predictions[^1].SetExtra(ExtraSerivce.Extras[random.Next(ExtraSerivce.Extras.Count)]);
            }

            return Ok(predictions);
        }


        [HttpPost("SetExtra")]
        public IActionResult SetExtra(string extra)
        {
            if (extra != null)
            {
                ExtraSerivce.Extras.Add(extra);
                return Ok();
            }
            return BadRequest("Extra == null");
        }

        [HttpDelete("ClearifyExtras")]
        public IActionResult Delete()
        {
            if (ExtraSerivce != null)
            {
                ExtraSerivce.Extras.Clear();
                return Ok();
            }
            return BadRequest("Extra == null");
        }
    }
}
