using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core.Json
{
    internal sealed class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
