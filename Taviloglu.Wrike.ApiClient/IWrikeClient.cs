using Taviloglu.Wrike.ApiClient.TimeLogCategories;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Provides methods to access and modify user content in Wrike through the API
    /// </summary>
    public interface IWrikeClient
    {
        IWrikeFoldersAndProjectsClient FoldersAndProjects { get; }
        IWrikeTasksClient Tasks { get; }
        IWrikeAccountsClient Accounts { get; }
        IWrikeGroupsClient Groups { get; }
        IWrikeUsersClient Users { get; }
        IWrikeContactsClient Contacts { get; }
        IWrikeCommentsClient Comments { get; }
        IWrikeIdsClient Ids { get; }
        IWrikeTimelogsClient Timelogs { get; }
        IWrikeColorsClient Colors { get; }
        IWrikeWebHooksClient WebHooks { get; }
        IWrikeInvitationsClient Invitations { get; }
        IWrikeAttachmentsClient Attachments { get; }
        IWrikeVersionClient Version { get; }
        IWrikeWorkflowsClient Workflows { get; }
        IWrikeCustomFieldsClient CustomFields { get; }
        IWrikeDependenciesClient Dependencies { get; }
        IWrikeTimelogCategoriesClient TimeLogCategories { get; }

        /// <summary>
        /// Refereshes the access token
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/oauth2"/>
        void RefreshToken();
    }
}