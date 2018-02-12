using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core.Json
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
