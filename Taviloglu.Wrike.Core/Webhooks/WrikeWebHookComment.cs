using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public class WrikeWebHookComment : IWrikeObject
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("html")]
        public string Html { get; set; }
    }
}
