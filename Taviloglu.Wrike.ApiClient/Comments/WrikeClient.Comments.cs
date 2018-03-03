using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeCommentsClient
    {
        public IWrikeCommentsClient Comments
        {
            get
            {
                return (IWrikeCommentsClient)this;
            }
        }

        Task<WrikeWebHook> IWrikeCommentsClient.CreateAsync(WrikeComment newComment, bool? plainText)
        {
            throw new NotImplementedException();
        }

        Task<WrikeTask> IWrikeCommentsClient.DeleteAsync(string commentId)
        {
            throw new NotImplementedException();
        }

        Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(string accountId, string folderId, string taskId, bool? plainText, int? limit, WrikeDateFilterRange updatedDate)
        {
            throw new NotImplementedException();
        }

        Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(List<string> commentIds, bool? plainText)
        {
            throw new NotImplementedException();
        }

        Task<WrikeWebHook> IWrikeCommentsClient.UpdateAsync(string text, bool? plainText)
        {
            throw new NotImplementedException();
        }
    }
}
