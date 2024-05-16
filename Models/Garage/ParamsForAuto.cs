using System.ComponentModel;

namespace DemoAPI.Models
{
    public class ParamsForAuto
    {
        public Dictionary<string, string> Test { get; set; } = new Dictionary<string, string>();
        [DefaultValue(null)]
        public long? Id { get; set; }
        [DefaultValue("")]
        public string Brand { get; set; }
        [DefaultValue("")]
        public string Model { get; set; }
        [DefaultValue(null)]
        public int? HorsePower { get; set; }
        [DefaultValue(null)]
        public EngineType EngineType { get; set; }

        public bool CheckParams()
        {
            if (Id == null ||
                string.IsNullOrEmpty(Brand) ||
                string.IsNullOrEmpty(Model) ||
                HorsePower == null)
            {
                return false;
            }

            return true;
        }
    }
}
