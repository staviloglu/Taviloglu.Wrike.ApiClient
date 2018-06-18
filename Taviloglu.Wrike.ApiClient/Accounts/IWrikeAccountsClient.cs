using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeAccountsClient
    {
        /// <summary>
        /// Returns all accounts to which user has access.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="metadata">Metadata filter, exact match for metadata key or key-value pair.</param>
        /// <param name="fields">Optional fields to be included in the response model Use <see cref="WrikeAccount.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-accounts"/>
        Task<List<WrikeAccount>> GetAsync(WrikeMetadata metadata = null, List<string> fields = null);


        /// <summary>
        /// Returns specified account.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="id">AccountId</param>
        /// <param name="fields">Optional fields to be included in the response model Use <see cref="WrikeAccount.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-accounts"/>
        Task<WrikeAccount> GetAsync(string id, List<string> fields = null);

        /// <summary>
        /// Update account by Id.
        /// SScopes: Default, wsReadWrite
        /// </summary>
        /// <param name="id">AccountId</param>
        /// <param name="metadataList">Metadata to be updated</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-account"/>
        Task<WrikeAccount> UpdateAsync(string id, List<WrikeMetadata> metadataList);
    }
}
