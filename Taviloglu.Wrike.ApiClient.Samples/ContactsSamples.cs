using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Extensions;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public class ContactsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var contacts = await client.Contacts.GetAsync();

            contacts = await client.Contacts.GetAsync(new List<string> { contacts.First().Id });

            contacts = await client.Contacts.GetAsync(me: true);

            contacts = await client.Contacts.GetAsync(me: true,
                retrieveMetadata: true);

            var updatedContact = await client.Contacts.UpdateAsync(
                "KUAERP25",
                new List<Core.WrikeMetadata>{new Core.WrikeMetadata("testMetaKey","testMetaValue")
            });

            var personTypeContacts = await client.Contacts.GetContactsByTypeAsync(WrikeUserType.Person);

           

        }
    }
}
