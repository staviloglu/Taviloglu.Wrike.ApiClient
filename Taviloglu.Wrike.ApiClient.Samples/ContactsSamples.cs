using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public class ContactsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var contacts = await client.Contacts.GetAsync();

            contacts = await client.Contacts.GetAsync(me: true);

            contacts = await client.Contacts.GetAsync(me: true,
                retrieveMetadata: true);

            contacts = await client.Contacts.GetAsync(accountId: "accountId");

            var updatedContact = await client.Contacts.UpdateAsync(
                "contactId", 
                new List<Core.WrikeMetadata>{new Core.WrikeMetadata("testMetaKey","testMetaValue")
            });

           

        }
    }
}
