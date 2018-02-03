using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeColor
    {
        /// <summary>
        /// Color name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        /// <summary>
        /// HEX code
        /// </summary>
        [DataMember(Name = "hex")]
        public string Hex { get; set; }
    }

}
