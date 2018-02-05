using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public abstract class WrikeObject
    {
       [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
