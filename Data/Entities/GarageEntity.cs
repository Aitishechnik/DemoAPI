namespace DemoAPI.Data.Entities
{
    public class GarageEntity : BaseEntity
    {
        public List<AutoEntity> Cars { get; set; }
        public string Name { get; set; }
    }
}
