using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeCustomFieldsClient
    {
        /// <summary>
        /// Returns a list of custom fields in all accessible accounts
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="accountId">If provided; returns a list of custom fields in particular account</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        Task<List<WrikeCustomField>> GetAsync(string accountId = null);

        /// <summary>
        /// Returns complete information about specified custom fields
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="customFieldIds">string list of customFiledIds</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        Task<List<WrikeCustomField>> GetAsync(List<string> customFieldIds);

        /// <summary>
        /// Create custom field in specified account
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <remarks></remarks>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-custom-field"/>
        /// <param name="customField">AccountId, Title and Text values should be set</param>
        Task<WrikeCustomField> CreateAsync(WrikeCustomField customField);

        /// <summary>
        /// Updates custom field
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-custom-field"/>        
        Task<WrikeCustomField> UpdateAsync(
            string id, string title = null, WrikeCustomFieldType? type = null, List<string> addShareds = null, List<string> removeShareds = null);
    }
}
