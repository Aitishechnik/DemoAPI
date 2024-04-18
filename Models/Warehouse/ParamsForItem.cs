using System.ComponentModel;

namespace DemoAPI.Models
{
    public class ParamsForItem()
    {
        [DefaultValue("")]
        public string? Name { get; set; }
        [DefaultValue(null)]
        public int? Category { get; set; }
        [DefaultValue("")]
        public string? Description { get; set; }

        public bool CheckParams()
        {
            if(string.IsNullOrEmpty(Name) ||
                Category == null ||
                string.IsNullOrEmpty(Description))
                return false;
            return true;
        }
    }
}
