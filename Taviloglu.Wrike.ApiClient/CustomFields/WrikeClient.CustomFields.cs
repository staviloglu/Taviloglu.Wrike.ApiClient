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
        async Task<WrikeResDto<WrikeCustomField>> IWrikeCustomFieldsClient.GetAsync(string accountId)
        {
            var requestUri = $"customfields";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/customfields";
            }

            return await SendRequest<WrikeCustomField>(requestUri, HttpMethods.Get);
        }

        async Task<WrikeResDto<WrikeCustomField>> IWrikeCustomFieldsClient.GetAsync(List<string> customFieldIds)
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
            return await SendRequest<WrikeCustomField>($"customfields/{customFieldsValue}", HttpMethods.Get);
        }

        async Task<WrikeResDto<WrikeCustomField>> IWrikeCustomFieldsClient.CreateAsync(WrikeCustomField customField)
        {

            if (customField == null)
            {
                throw new ArgumentNullException("CustomField can not be null");
            }
            if (string.IsNullOrWhiteSpace(customField.AccountId))
            {
                throw new ArgumentNullException("customField.AccountId can not be null or empty");
            }

            var data = new List<KeyValuePair<string, string>>();

            data.Add(new KeyValuePair<string, string>("title", customField.Title));
            data.Add(new KeyValuePair<string, string>("type", customField.Type.ToString()));
            if (customField.SharedIds != null && customField.SharedIds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("shareds", JsonConvert.SerializeObject(customField.SharedIds)));
            }

            var postContent = new FormUrlEncodedContent(data);

            return await SendRequest<WrikeCustomField>($"accounts/{customField.AccountId}/customfields",
                HttpMethods.Post, postContent);
        }

        async Task<WrikeResDto<WrikeCustomField>> IWrikeCustomFieldsClient.UpdateAsync(
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

            var data = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(title))
            {
                data.Add(new KeyValuePair<string, string>("title", title));
            }

            if (type != null)
            {
                data.Add(new KeyValuePair<string, string>("type", type.ToString()));

            }
            if (addShareds != null && addShareds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("addShareds", JsonConvert.SerializeObject(addShareds)));
            }
            if (removeShareds != null && removeShareds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("removeShareds", JsonConvert.SerializeObject(removeShareds)));
            }

            var putContent = new FormUrlEncodedContent(data);

            return await SendRequest<WrikeCustomField>($"customfields/{id}", HttpMethods.Put, putContent);
        }
    }
}
