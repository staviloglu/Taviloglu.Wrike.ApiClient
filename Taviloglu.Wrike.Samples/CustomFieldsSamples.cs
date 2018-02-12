using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.Samples
{
    public static class CustomFieldsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var customFields = await client.CustomFields.GetAsync();

            customFields = await client.CustomFields.GetAsync(new List<string> { "customFieldId", "customFieldId" });

            var newCustomField = new WrikeCustomField
            {
                AccountId = "accountId",
                Title = "New Custom Field",
                Type = WrikeCustomFieldType.Duration
            };
            newCustomField = await client.CustomFields.CreateAsync(newCustomField);

            //TODO: returns invalid-parameter error if type is not Text
            var updatedCustomField = await client.CustomFields.UpdateAsync(
                newCustomField.Id,
                title: "Updated New Custom Field",
                type: WrikeCustomFieldType.Money);
            
        }
    }
}
