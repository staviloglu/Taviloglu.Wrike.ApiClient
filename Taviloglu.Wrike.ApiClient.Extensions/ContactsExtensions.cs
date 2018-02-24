using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class ContactsExtensions
    {
        public static async Task<List<WrikeUser>> GetAsync(this IWrikeContactsClient wrikeContactsClient, WrikeUserType type, string accountId = null, bool? me = null, WrikeMetadata metadata = null, bool? retrieveMetadata = null)
        {
            var contacts = await wrikeContactsClient.GetAsync(accountId, me, metadata, retrieveMetadata);
            return contacts.Where(c => c.Type == type).ToList();
        }
    }
}
