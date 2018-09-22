using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Account operations
    /// </summary>
    public interface IWrikeAccountsClient
    {
        /// <summary>
        /// Returns all accounts to which user has access.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="metadata">Metadata filter, exact match for metadata key or key-value pair.</param>
        /// <param name="fields">Optional fields to be included in the response model Use <see cref="WrikeAccount.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-accounts"/>
        Task<WrikeAccount> GetAsync(WrikeMetadata metadata = null, List<string> fields = null);

        /// <summary>
        /// Update current account.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="metadataList">Metadata to be updated</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-account"/>
        Task<WrikeAccount> UpdateAsync(List<WrikeMetadata> metadataList);
    }
}
