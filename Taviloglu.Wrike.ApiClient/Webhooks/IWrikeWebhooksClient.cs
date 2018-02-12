using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeWebHooksClient
    {
        /// <summary>
        ///  Creates a webhook for a particular account.
        /// </summary>
        /// <param name="newWebhook"></param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<WrikeWebHook> CreateAsync(WrikeWebHook newWebhook);

        /// <summary>
        /// Returns a list of all existing webhooks
        /// </summary>
        /// <param name="accountId">Returns a list of webhooks in a specified account.</param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<List<WrikeWebHook>> GetAsync(string accountId = null);

        /// <summary>
        /// Returns information for the specified webhooks.
        /// </summary>
        /// <param name="webhookIds">Max count 100</param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<List<WrikeWebHook>> GetAsync(List<string> webhookIds);

        /// <summary>
        /// Deletes webhook by ID.
        /// </summary>
        /// <param name="webhookId"></param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task DeleteAsync(string webhookId);

        /// <summary>
        ///   Modifies the webhooks state to suspend or resume. Suspended webhooks do not send notifications.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="webhookId"></param>
        /// See <see href="https://developers.wrike.com/documentation/webhooks"/>
        Task<WrikeWebHook> UpdateAsync(string webhookId, WrikeWebhookStatus status);


    }
}
