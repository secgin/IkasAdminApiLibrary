using Newtonsoft.Json;

namespace IkasAdminApiLibrary.Utils
{
    internal class UnixDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                if (objectType == typeof(DateTime?))
                    return null;

                throw new JsonSerializationException("Cannot convert null value to DateTime.");
            }

            if (reader.TokenType != JsonToken.Integer)
                throw new JsonSerializationException($"Unexpected token parsing date. Expected Integer, got {reader.TokenType}.");

            if (reader.Value == null)
                return null;

            long milliseconds = (long)reader.Value;
            return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).DateTime;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
