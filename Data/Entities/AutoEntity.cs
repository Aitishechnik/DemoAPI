using DemoAPI.Models;

namespace DemoAPI.Data.Entities
{
    public class AutoEntity : BaseEntity
    {
        public long Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? HorsePower { get; set; }
        public EngineType? EngineType { get; set; }

        public GarageEntity? Garage { get; set; }
        
        public long? GarageId { get; set; }

        public AutoEntity() { }

        public AutoEntity(ParamsForAuto paramsForAuto)
        {
            Id = (long)paramsForAuto.Id;
            Brand = paramsForAuto.Brand;
            Model = paramsForAuto.Model;
            HorsePower = paramsForAuto.HorsePower;
            EngineType = paramsForAuto.EngineType;
        }
    }
}
