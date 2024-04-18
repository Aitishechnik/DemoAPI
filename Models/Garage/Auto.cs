namespace DemoAPI.Models
{
    public class Auto
    {
        public long Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? HorsePower { get; set; }
        public EngineType? EngineType { get; set; }
        public Dictionary<string, string> Test { get; set; } = [];

        public Auto(ParamsForAuto paramsForAuto)
        {
            Id = (long)paramsForAuto.Id;
            Brand = paramsForAuto.Brand;
            Model = paramsForAuto.Model;
            HorsePower = paramsForAuto.HorsePower;
            EngineType = paramsForAuto.EngineType;
            Test = paramsForAuto.Test;
        }
    }
}
