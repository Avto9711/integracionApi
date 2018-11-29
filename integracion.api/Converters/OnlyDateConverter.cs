using Newtonsoft.Json.Converters;

namespace Integracion.api.converters
    {
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
    }
    
 