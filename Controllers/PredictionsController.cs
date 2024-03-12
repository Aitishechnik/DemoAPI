using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredictionsController : ControllerBase
    {
        private readonly ILogger<PredictionsController> _logger;

        public PredictionsController(ILogger<PredictionsController> logger)
        {
            _logger = logger;
        }
        static Random random = new Random();
        private readonly string[] ZodiacSigns = { "Овен: ", "Телец: ", "Близнецы: ", "Рак: ", "Лев: ", "Дева: ", "Весы: ", "Скорпион: ", "Стрелец: ", "Козерог: ", "Водолей: ", "Рыбы: " };
        private readonly string[] Periods = { "Всю неделю ", "Весь месяц ", "Весть год " };
        private readonly string[] Actions = {"катайтесь на самоекате ", "сидите на мягких стулья ", "прыгайте по лужам ", "берите кредиты в больших количествах ", "управляйте авто с закрытыми глазами ", "пейте колу ", "стойте на одной ноге " };
        private readonly string[] Subjects = { "больше часа в день.", "возле свалки.", "не переживая за последсвтия.", "рядом с другими людьми."};
        private static List<string>? Extras = new List<string>();
        [HttpGet("GetPredition")]
        public IEnumerable<Predictions> Get()
        {
            List<Predictions> predictions = new List<Predictions>();

            foreach (var sign in ZodiacSigns) {
                predictions.Add(new Predictions(sign, 
                    Periods[random.Next(Periods.Length)], 
                    Actions[random.Next(Actions.Length)],
                    Subjects[random.Next(Subjects.Length)]));
                if(Extras!=null && Extras.Count > 0)
                predictions[predictions.Count - 1].SetExtra(Extras[random.Next(Extras.Count)]);
            }
            
            return predictions;
        }

        [HttpPost("SetExtra")]
        public void SetExtra(string extra)
        {
            if (extra != null)
                Extras.Add(extra);
        }

        [HttpDelete("ClearifyExtras")]
        public void Delete()
        {
            if (Extras != null)
                Extras.Clear();
        }
    }
}
