using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Accounts;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class AccountsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var currentAccount = await client.Accounts.GetAsync();


            var optionalFields = new List<string> {
                WrikeAccount.OptionalFields.Metadata,
                WrikeAccount.OptionalFields.CustomFields,
                WrikeAccount.OptionalFields.Subscription
            };
            currentAccount = await client.Accounts.GetAsync(optionalFields: optionalFields);


            var metadataList = new List<WrikeMetadata> { new WrikeMetadata("testMetadata", "testMetadata") };
            currentAccount = await client.Accounts.UpdateAsync(metadataList);
        }
    }
}
