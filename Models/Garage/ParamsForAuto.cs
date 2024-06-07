using System.ComponentModel;

namespace DemoAPI.Models
{
    public class ParamsForAuto
    {
        public long? Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? HorsePower { get; set; }
        public EngineType EngineType { get; set; }
        public long? GarageId { get; set; }
    }
}
