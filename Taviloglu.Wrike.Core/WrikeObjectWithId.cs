using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    /// <summary>
    /// Any object having an ID
    /// </summary>
    public abstract class WrikeObjectWithId : IWrikeObject
    {
        /// <summary>
        /// Id of the object
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
