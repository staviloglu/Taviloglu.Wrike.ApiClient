using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.CustomFields;

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
        async Task<List<WrikeCustomField>> IWrikeCustomFieldsClient.GetAsync()
        {
            var response = await SendRequest<WrikeCustomField>("customfields", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeCustomField>> IWrikeCustomFieldsClient.GetAsync(WrikeClientIdListParameter customFieldIds)
        {   
            var response = await SendRequest<WrikeCustomField>($"customfields/{customFieldIds}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeCustomField> IWrikeCustomFieldsClient.CreateAsync(WrikeCustomField newCustomField)
        {
            if (newCustomField == null)
            {
                throw new ArgumentNullException(nameof(newCustomField));
            }

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", newCustomField.Title)
                .AddParameter("type", newCustomField.Type)
                .AddParameter("shareds", newCustomField.SharedIds)
                .AddParameter("settings", newCustomField.Settings);


            var response = await SendRequest<WrikeCustomField>("customfields",
                HttpMethods.Post, postDataBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeCustomField> IWrikeCustomFieldsClient.UpdateAsync(
            WrikeClientIdParameter id,
            string title,
            WrikeCustomFieldType? type,
            List<string> addShareds,
            List<string> removeShareds,
            WrikeCustomFieldSettings settings)
        {
            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", title)
                .AddParameter("type", type)
                .AddParameter("addShareds", addShareds)
                .AddParameter("removeShareds", removeShareds)
                .AddParameter("settings", settings);

            var response = await SendRequest<WrikeCustomField>($"customfields/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}
