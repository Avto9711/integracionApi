using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Integracion.api.converters
{
    public class DecimalCurrencyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(decimal));
    }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                {
                    if ((string)reader.Value == string.Empty)
                    {
                        return decimal.MinValue;
                    }
                }
                else if (reader.TokenType == JsonToken.Float || 
                        reader.TokenType == JsonToken.Integer)
                {
                    return Convert.ToDecimal(reader.Value);
                }

                throw new JsonSerializationException("Unexpected token type: " +
                                                    reader.TokenType.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        decimal dec = (decimal)value;
        if (dec == decimal.MinValue)
        {
            writer.WriteValue(string.Empty);
        }
        else
        {
            writer.WriteValue(dec.ToString("C"));
        }        
        }
    }
}
    
 