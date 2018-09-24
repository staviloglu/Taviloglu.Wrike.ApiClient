using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public sealed class WrikeWebHookCommentEvent : WrikeWebHookEvent
    {
        [JsonProperty("commentId")]
        public string CommentId { get; set; }

        [JsonProperty("comment")]
        public WrikeWebHookComment Comment { get; set; }
    }
}
