using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeColor
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "hex")]
        public string Hex { get; set; }
    }

}
