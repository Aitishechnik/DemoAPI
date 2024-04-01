namespace DemoAPI.Models
{
    public class Predictions
    {
        public string Zodiac { get; set; }

        public string Period { get; set; }

        public string PredictedAction { get; set; }

        public string PredictedSubject { get; set; }

        public string? ExtraInforamation { get; set; }

        public Predictions(string zodiac, string period, string acton, string subject)
        {
            Zodiac = zodiac;
            Period = period;
            PredictedAction = acton;
            PredictedSubject = subject;
        }

        public void SetExtra(string extra)
        {
            ExtraInforamation = extra;
        }
    }
}
