using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeColor
    {
        /// <summary>
        /// Color name
        /// </summary>
       [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// HEX code
        /// </summary>
       [JsonProperty(PropertyName = "hex")]
        public string Hex { get; set; }
    }

}
