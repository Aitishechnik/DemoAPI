using System.Text.Json.Serialization;
using DemoAPI.Utilities;

namespace DemoAPI.Models
{
    [JsonConverter(typeof(EnumStringConverter<EngineType>))]
    public enum EngineType { Patrol, Disel, Electro, Hybrid}
}
