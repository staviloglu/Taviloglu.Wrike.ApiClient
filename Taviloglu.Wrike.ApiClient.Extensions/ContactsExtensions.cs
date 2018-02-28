using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class ContactsExtensions
    {
        public static async Task<List<WrikeUser>> GetContactsByTypeAsync(this IWrikeContactsClient wrikeContactsClient, WrikeUserType type, string accountId = null, bool? me = null, WrikeMetadata metadata = null, bool? retrieveMetadata = null)
        {
            var contacts = await wrikeContactsClient.GetAsync(accountId, me, metadata, retrieveMetadata);
            return contacts.Where(c => c.Type == type).ToList();
        }

        /// <summary>
        /// Retrieves the first contact record having type person and provided email 
        /// </summary>
        /// <param name="email"></param>
        public static async Task<WrikeUser> GetContactByEmailAsync(this IWrikeContactsClient wrikeContactsClient,string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var contacts = await wrikeContactsClient.GetAsync();
            return contacts.Where(c =>
            c.Type == WrikeUserType.Person &&
            c.Profiles.Any(p=> p.Email == email)).FirstOrDefault();
        }
    }
}
