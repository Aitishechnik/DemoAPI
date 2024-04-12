using System.Text.Json.Serialization;
using System.Text.Json;

namespace DemoAPI.Utilities
{
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
