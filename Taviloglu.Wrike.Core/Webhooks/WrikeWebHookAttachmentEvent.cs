using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.WebHooks
{
    public sealed class WrikeWebHookAttachmentEvent : WrikeWebHookEvent
    {
        [JsonProperty("attachmentId")]
        public string AttachmentId { get; set; }
    }
}
