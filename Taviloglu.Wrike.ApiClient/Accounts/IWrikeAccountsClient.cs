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
        /// <param name="fields">Json string array of optional fields to be included in the response model. Use <see cref="WrikeAccount.OptionalFields"/> </param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-accounts"/>
        Task<List<WrikeAccount>> GetAsync(WrikeMetadata metadata = null,List<string> fields = null);

    }
}
