using Newtonsoft.Json;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.Comments
{
    public class WrikeFolderComment : WrikeComment
    {
        public WrikeFolderComment(string text, string folderId) : base(text)
        {
            folderId.ValidateParameter(nameof(folderId));

            FolderId = folderId;
        }

        /// <summary>
        /// ID of related folder.
        /// </summary>
        [JsonProperty("folderId")]
        public string FolderId { get; private set; }
    }
}
