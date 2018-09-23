using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taviloglu.Wrike.Core
{
    public class WrikeFolderComment : WrikeComment
    {
        public WrikeFolderComment(string text, string folderId) : base(text)
        {
            if (folderId == null)
            {
                throw new ArgumentNullException(nameof(folderId));
            }

            if (folderId.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(folderId));
            }

            FolderId = folderId;
        }

        /// <summary>
        /// ID of related folder.
        /// </summary>
        [JsonProperty("folderId")]
        public string FolderId { get; private set; }
    }
}
