using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class AccountsSamples
    {
        public static async Task Run(WrikeClient client)
        {

            var accounts = await client.Accounts.GetAsync();

            var account = await client.Accounts.GetAsync(accounts[0].Id, new List<string> { WrikeAccount.OptionalFields.Subscription, WrikeAccount.OptionalFields.Metadata });

            account = await client.Accounts.UpdateAsync(accounts[0].Id, account.Metadata);

            //Get all timelog categorie in the account.
            //var timelogCategories = await client.Accounts.GetTimelogCategories("IEABX2HE");

        }
    }
}
