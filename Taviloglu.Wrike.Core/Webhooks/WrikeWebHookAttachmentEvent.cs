using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public sealed class WrikeWebHookAttachmentEvent : WrikeWebHookEvent
    {
        [JsonProperty("attachmentId")]
        public string AttachmentId { get; set; }
    }
}
