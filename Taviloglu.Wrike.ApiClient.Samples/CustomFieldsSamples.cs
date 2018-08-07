using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class CustomFieldsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var customFields = await client.CustomFields.GetAsync();


            foreach (var customField in customFields)
            {
                await client.CustomFields.UpdateAsync(customField.Id, type:customField.Type);

            }


            //customFields = await client.CustomFields.GetAsync(new List<string> { "customFieldId", "customFieldId" });

            //var newCustomField = new WrikeCustomField
            //{
            //    AccountId = "accountId",
            //    Title = "New Custom Field",
            //    Type = WrikeCustomFieldType.Duration
            //};
            //newCustomField = await client.CustomFields.CreateAsync(newCustomField);

            //TODO: returns invalid-parameter error if type is not Text
            customFields[18].Settings.DecimalPlaces = 0;
            customFields[18].Settings.Aggregation  = WrikeCustomFieldAggregationType.None;

            var updatedCustomField = await client.CustomFields.UpdateAsync(
                customFields[18].Id,
                settings: customFields[18].Settings);
            
        }
    }
}
