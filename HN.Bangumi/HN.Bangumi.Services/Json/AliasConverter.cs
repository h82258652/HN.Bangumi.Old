using System;
using HN.Bangumi.Models;
using Newtonsoft.Json;

namespace HN.Bangumi.Json
{
    public class AliasConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return serializer.Deserialize(reader, objectType);
            }
            catch (JsonSerializationException)
            {
                var alias = serializer.Deserialize<string[]>(reader);
                return new Alias()
                {
                    Kana = alias[0]
                };
            }
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}