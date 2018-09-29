using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Attachments
{
    public sealed class WrikeTaskAttachment : WrikeAttachment
    {        
        /// <summary>
        /// ID of related task. Only one of taskId/folderId fields is present
        /// </summary>
        [JsonProperty("taskId")]
        public string TaskId { get; set; }
    }
}
