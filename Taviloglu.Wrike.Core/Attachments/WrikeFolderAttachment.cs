using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Attachments
{
    public class WrikeFolderAttachment : WrikeAttachment
    {
        /// <summary>
        /// ID of related folder. Only one of taskId/folderId fields is present
        /// </summary>
        [JsonProperty("folderId")]
        public string FolderId { get; set; }

    }
}
