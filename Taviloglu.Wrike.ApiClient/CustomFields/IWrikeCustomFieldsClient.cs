using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.CustomFields;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Custom Field operations
    /// </summary>
    public interface IWrikeCustomFieldsClient
    {
        /// <summary>
        /// Returns a list of custom fields in current account.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        Task<List<WrikeCustomField>> GetAsync();

        /// <summary>
        /// Returns complete information about specified custom fields
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="customFieldIds"></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        Task<List<WrikeCustomField>> GetAsync(List<string> customFieldIds);

        /// <summary>
        /// Create custom field in specified account
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="newCustomField"></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-custom-field"/>
        Task<WrikeCustomField> CreateAsync(WrikeCustomField newCustomField);

        /// <summary>
        /// Updates custom field
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="id">CustomFieldId</param>
        /// <param name="title">Custom field title</param>
        /// <param name="type">Custom field type </param>
        /// <param name="addShareds">Share custom field with specified users</param>
        /// <param name="removeShareds">Unshare custom field from specified users</param>
        /// <param name="settings">Custom field type settings</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-custom-field"/>        
        Task<WrikeCustomField> UpdateAsync(
            string id, string title = null, WrikeCustomFieldType? type = null, List<string> addShareds = null, List<string> removeShareds = null, WrikeCustomFieldSettings settings = null);
    }
}
