using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomField
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }

}
