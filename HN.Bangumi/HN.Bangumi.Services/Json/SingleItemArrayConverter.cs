using System;
using Newtonsoft.Json;

namespace HN.Bangumi.Json
{
    public class SingleItemArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return serializer.Deserialize(reader, objectType);
            }
            catch (JsonSerializationException)
            {
                var elementType = objectType.GetElementType();
                var element = serializer.Deserialize(reader, elementType);
                var array = Array.CreateInstance(elementType, 1);
                array.SetValue(element, 0);
                return array;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}