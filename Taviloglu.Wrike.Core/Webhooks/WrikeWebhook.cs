using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Taviloglu.Wrike.Core.Webhooks
{
    /// <summary>
    /// Webhooks allow you to subscribe to notifications about changes in Wrike instead of having to rely on periodic polling. 
    /// </summary>
    public sealed class WrikeWebHook : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeWebHook"></see> class with the
        ///  url of the server which will receive the payload.
        /// </summary>
        /// <param name="hookUrl">URL of the server which will receive the payload.</param>
        public WrikeWebHook(string hookUrl)
        {
            if (hookUrl == null)
            {
                throw new ArgumentNullException(nameof(hookUrl));
            }

            if (hookUrl==string.Empty)
            {
                throw new ArgumentException($"{nameof(hookUrl)} can not be empty string", nameof(hookUrl));
            }

            HookUrl = hookUrl;
        }

        /// <summary>
        /// Account Id
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; private set; }

        /// <summary>
        /// Folder Id
        /// </summary>
        [JsonProperty("folderId")]
        public string FolderId { get; set; }

        /// <summary>
        /// URL of the server which will receive the payload.
        /// </summary>
        [JsonProperty("hookUrl")]
        public string HookUrl { get; private set; }

        /// <summary>
        /// State of thw webhook
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeWebHookStatus Status { get; set; }
    }
    

}
