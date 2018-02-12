using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public abstract class WrikeObjectWithId : IWrikeObject
    {
       [JsonProperty("id")]
        public string Id { get; set; }

        internal WrikeObjectWithId() { }
    }
}
