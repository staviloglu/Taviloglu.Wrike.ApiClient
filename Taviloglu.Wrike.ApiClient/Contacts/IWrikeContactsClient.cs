using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeContactsClient
    {
        //TODO: write some code!


        /// <summary>
        /// List contacts of all users and user groups in all accessible accounts.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="accountId">List contacts of all users and user groups in account.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-contacts"/>
        Task<List<WrikeUser>> GetAsync(string accountId = null, 
            bool? me = null, 
            WrikeMetadata metadata = null, 
            bool? retrieveMetadata = null);

        /// <summary>
        /// List contacts of specified users and user groups.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="contactIds">string list of contactIds</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-contacts"/>
        Task<List<WrikeUser>> GetAsync(List<string> contactIds, WrikeMetadata metadata = null, bool? retrieveMetadata = null);

        /// <summary>
        /// Update contacts by Id.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-contact"/>        
        Task<WrikeUser> UpdateAsync(string id, List<WrikeMetadata> metadata = null);
    }
}
