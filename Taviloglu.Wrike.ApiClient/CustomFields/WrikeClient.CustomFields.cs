using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeCustomFieldsClient
    {
        public IWrikeCustomFieldsClient CustomFields
        {
            get
            {
                return (IWrikeCustomFieldsClient)this;
            }
        }
        async Task<List<WrikeCustomField>> IWrikeCustomFieldsClient.GetAsync(string accountId)
        {
            var requestUri = $"customfields";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/customfields";
            }

            var response =  await SendRequest<WrikeCustomField>(requestUri, HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeCustomField>> IWrikeCustomFieldsClient.GetAsync(List<string> customFieldIds)
        {

            if (customFieldIds == null || customFieldIds.Count < 1)
            {
                throw new ArgumentNullException("customFieldIds can not be null or empty");
            }
            if (customFieldIds.Count > 100)
            {
                throw new ArgumentException("customFieldIds max count is 100");
            }

            var customFieldsValue = string.Join(",", customFieldIds);
            var response = await SendRequest<WrikeCustomField>($"customfields/{customFieldsValue}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeCustomField> IWrikeCustomFieldsClient.CreateAsync(WrikeCustomField customField)
        {

            if (customField == null)
            {
                throw new ArgumentNullException("CustomField can not be null");
            }
            if (string.IsNullOrWhiteSpace(customField.AccountId))
            {
                throw new ArgumentNullException("customField.AccountId can not be null or empty");
            }

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", customField.Title)
                .AddParameter("type", customField.Type)
                .AddParameter("shareds", customField.SharedIds);
            

            var response = await SendRequest<WrikeCustomField>($"accounts/{customField.AccountId}/customfields",
                HttpMethods.Post, postDataBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeCustomField> IWrikeCustomFieldsClient.UpdateAsync(
            string id,
            string title,
            WrikeCustomFieldType? type,
            List<string> addShareds,
            List<string> removeShareds)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", title)
                .AddParameter("type", type)
                .AddParameter("addShareds", addShareds)
                .AddParameter("removeShareds", removeShareds);

            

            var response = await SendRequest<WrikeCustomField>($"customfields/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}
