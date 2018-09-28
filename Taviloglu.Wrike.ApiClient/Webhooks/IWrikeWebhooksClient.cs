using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.WebHooks;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// WebHook operations
    /// </summary>
    public interface IWrikeWebHooksClient
    {
        /// <summary>
        ///  Creates a webhook for a particular account.
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="newWebHook"></param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<WrikeWebHook> CreateAsync(WrikeWebHook newWebHook);

        /// <summary>
        /// Returns a list of all existing webhooks
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<List<WrikeWebHook>> GetAsync();

        /// <summary>
        /// Returns information for the specified webhooks.
        /// </summary>
        /// <param name="webhookIds">Max count 100</param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<List<WrikeWebHook>> GetAsync(WrikeClientIdListParameter webhookIds);

        /// <summary>
        /// Deletes webhook by ID.
        /// </summary>
        /// <param name="webhookId"></param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task DeleteAsync(WrikeClientIdParameter webhookId);

        /// <summary>
        ///   Modifies the webhooks state to suspend or resume. Suspended webhooks do not send notifications.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="webhookId"></param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<WrikeWebHook> UpdateAsync(WrikeClientIdParameter webhookId, WrikeWebHookStatus status);
    }
}
