using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text.Json;
using static DemoAPI.Models.ParamsForAuto;
using System;

namespace DemoAPI.Models
{
    public class Garage
    {
        public Dictionary<long, Auto> CarPark { get; set; } = [];
    }
    [JsonConverter(typeof(EnumStringConverter<EngineType>))]
    public enum EngineType { Patrol, Disel, Electro, Hybrid}
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

    public class ParamsForAuto()
    {
        public Dictionary<string, string> Test { get; set; } = [];
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

        public class EnumStringConverter<T> : JsonConverter<T> where T : struct, Enum
        {
            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return Enum.Parse<T>(reader.GetString(), ignoreCase: true);
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
