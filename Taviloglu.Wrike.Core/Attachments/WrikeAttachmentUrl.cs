using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Attachments
{
    public class WrikeAttachmentUrl : IWrikeObject
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
