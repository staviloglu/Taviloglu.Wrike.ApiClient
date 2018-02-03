using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeKeyValue
    {
        [DataMember(Name="key")]
        public string Key { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
