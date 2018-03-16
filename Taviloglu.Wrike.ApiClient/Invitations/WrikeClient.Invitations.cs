using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Invitations;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeInvitationsClient
    {
        public IWrikeInvitationsClient Invitations
        {
            get
            {
                return (IWrikeInvitationsClient)this;
            }
        }

        async Task<WrikeInvitation> IWrikeInvitationsClient.CreateAsync(WrikeInvitation newInvitation, string subject, string message)
        {
            if (newInvitation == null)
            {
                throw new ArgumentNullException(nameof(newInvitation),
                    "newInvitation can not be null, do not use empty ctor");
            }

            if (string.IsNullOrWhiteSpace(newInvitation.Email))
            {
                throw new ArgumentNullException(nameof(newInvitation.Email),
                    "newInvitation.Email can not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(newInvitation.AccountId))
            {
                throw new ArgumentNullException(nameof(newInvitation.AccountId),
                    "newInvitation.AccountId can not be null or empty");
            }
            

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("email", newInvitation.Email)
                .AddParameter("firstName", newInvitation.FirstName)
                .AddParameter("lastName", newInvitation.LastName)
                .AddParameter("role", newInvitation.Role)
                .AddParameter("external", newInvitation.External)
                .AddParameter("subject", subject)
                .AddParameter("message", message);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeInvitation>($"accounts/{newInvitation.AccountId}/invitations", HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeInvitationsClient.DeleteAsync(string invitationId)
        {
            if (string.IsNullOrWhiteSpace(invitationId))
            {
                throw new ArgumentNullException(nameof(invitationId), "invitationId can not be null or empty");
            }

            await SendRequest<WrikeInvitation>($"invitations/{invitationId}", HttpMethods.Delete).ConfigureAwait(false);
        }

        async Task<List<WrikeInvitation>> IWrikeInvitationsClient.GetAsync(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentNullException(nameof(accountId), "accountId can not be null or empty");
            }

            var response = await SendRequest<WrikeInvitation>($"accounts/{accountId}/invitations", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeInvitation> IWrikeInvitationsClient.UpdateAsync(string invitationId, bool? resend, WrikeUserRole? role, bool? external)
        {
            if (string.IsNullOrWhiteSpace(invitationId))
            {
                throw new ArgumentNullException(nameof(invitationId), "invitationId can not be null or empty");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("resend", resend)
                .AddParameter("role", role)
                .AddParameter("external", external);

            var response = await SendRequest<WrikeInvitation>($"invitations/{invitationId}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}
