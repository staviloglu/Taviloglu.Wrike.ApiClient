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
            if (newTimeLog == null)
            {
                throw new ArgumentException(nameof(newTimeLog));
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

        async Task<WrikeTimelog> IWrikeTimelogsClient.UpdateAsync(string id, string comment, int? hours, DateTime? trackedDate, bool? plainText, string categoryId)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(id), "id can not be empty");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
               .AddParameter("comment", comment)
               .AddParameter("hours", hours)
               .AddParameter("trackedDate", trackedDate)
               .AddParameter("plainText", plainText)
               .AddParameter("categoryId", categoryId);

            var response = await SendRequest<WrikeTimelog>($"timelogs/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeTimelogsClient.DeleteAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(id), "id can not be empty");
            }

            var response = await SendRequest<WrikeTimelog>($"timelogs/{id}", HttpMethods.Delete).ConfigureAwait(false);
        }

        async Task<List<WrikeTimelog>> IWrikeTimelogsClient.GetAsync(string contactId, string folderId, string taskId, string categoryId, WrikeDateFilterRange createdDate, IWrikeDateFilter trackedDate, bool? me, bool? descendants, bool? subTasks, bool? plainText, List<string> categoryIds)
        {

            int notNullCount = 0;

            string requestUri = "timelogs";

            if (!string.IsNullOrWhiteSpace(contactId))
            {
                requestUri = $"contacts/{contactId}/timelogs";
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

            if (notNullCount > 1) throw new ArgumentException("only one of contactId, folderId, taskId or categoryId can be used");

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

        async Task<WrikeTimelog> IWrikeTimelogsClient.GetAsync(string id, bool? plainText)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(id), "id can not be empty");
            }

            var uriBuilder = new WrikeGetUriBuilder($"timelogs/{id}")
            .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeTimelog>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}
