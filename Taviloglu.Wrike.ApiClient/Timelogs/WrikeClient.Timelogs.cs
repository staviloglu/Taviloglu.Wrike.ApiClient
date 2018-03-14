using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;
using Taviloglu.Wrike.Core.Timelogs;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeTimelogsClient
    {
        public IWrikeTimelogsClient Timelogs
        {
            get
            {
                return (IWrikeTimelogsClient)this;
            }
        }

        async Task<WrikeTimelog> IWrikeTimelogsClient.CreateAsync(WrikeTimelog newTimeLog, bool? plainText)
        {

            if (string.IsNullOrWhiteSpace(newTimeLog.TaskId))
            {
                throw new ArgumentNullException(nameof(newTimeLog.TaskId), "newTimeLog.TaskId can not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(newTimeLog.Comment))
            {
                throw new ArgumentNullException(nameof(newTimeLog.Comment), "newTimeLog.Comment can not be null or empty");
            }

            var requestUri = $"tasks/{newTimeLog.TaskId}/timelogs";

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("comment", newTimeLog.Comment)
                .AddParameter("hours", newTimeLog.Hours)
                .AddParameter("trackedDate", newTimeLog.TrackedDate.ToString("yyyy-MM-dd"))
                .AddParameter("plainText", plainText)
                .AddParameter("categoryId", newTimeLog.CategoryId);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeTimelog>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeTimelog> IWrikeTimelogsClient.UpdateAsync(string timelogId, string comment, int? hours, DateTime? trackedDate, bool? plainText, string categoryId)
        {
            if (string.IsNullOrWhiteSpace(timelogId))
            {
                throw new ArgumentNullException(nameof(timelogId), "timelogId can not be null or empty");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
               .AddParameter("comment", comment)
               .AddParameter("hours", hours)
               .AddParameter("trackedDate", trackedDate)
               .AddParameter("plainText", plainText)
               .AddParameter("categoryId", categoryId);

            var response = await SendRequest<WrikeTimelog>($"timelogs/{timelogId}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeTimelogsClient.DeleteAsync(string timelogId)
        {

            if (string.IsNullOrWhiteSpace(timelogId))
            {
                throw new ArgumentNullException(nameof(timelogId), "timelogId can not be null or empty");
            }

            var response = await SendRequest<WrikeTimelog>($"timelogs/{timelogId}", HttpMethods.Delete).ConfigureAwait(false);
        }

        async Task<List<WrikeTimelog>> IWrikeTimelogsClient.GetAsync(string contactId, string accountId, string folderId, string taskId, string categoryId, WrikeDateFilterRange createdDate, IWrikeDateFilter trackedDate, bool? me, bool? descendants, bool? subTasks, bool? plainText, List<string> categoryIds)
        {

            int notNullCount = 0;

            string requestUri = "timelogs";
            
            if (!string.IsNullOrWhiteSpace(contactId))
            {
                requestUri = $"contacts/{contactId}/timelogs";
                notNullCount++;
            }
            else if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/timelogs";
                notNullCount++;
            }
            else if (!string.IsNullOrWhiteSpace(folderId))
            {
                requestUri = $"folders/{folderId}/timelogs";
                notNullCount++;
            }
            else if (!string.IsNullOrWhiteSpace(taskId))
            {
                requestUri = $"tasks/{taskId}/timelogs";
                notNullCount++;
            }
            else if (!string.IsNullOrWhiteSpace(categoryId))
            {
                requestUri = $"timelog_categories/{categoryId}/timelogs";
                notNullCount++;
            }

            if (notNullCount > 1) throw new ArgumentException("only one of timelogId, contactId, accountId, folderId, taskId or categoryId can be used");

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
            .AddParameter("createdDate", createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("trackedDate", trackedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss"))
            .AddParameter("me", me)
            .AddParameter("descendants", descendants)
            .AddParameter("subTasks", subTasks)
            .AddParameter("plainText", plainText)
            .AddParameter("timelogCategories", categoryIds);

            var response = await SendRequest<WrikeTimelog>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeTimelog> IWrikeTimelogsClient.GetAsync(string timelogId, bool? plainText)
        {
            var uriBuilder = new WrikeGetUriBuilder($"timelogs/{timelogId}")
            .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeTimelog>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}
