using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Invitations;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class InvitationsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var newInvitation = new WrikeInvitation(email:"s.taviloglu@gmail.com"
                , firstName:"Sinann", lastName:"Tavilogluu", role:WrikeUserRole.Collaborator);

            newInvitation = await client.Invitations.CreateAsync(newInvitation, "Invitation Subject", "Invitation Message");

            var invitations = await client.Invitations.GetAsync();

            var updatedInvitation = await client.Invitations.UpdateAsync(newInvitation.Id, resend: true);

            await client.Invitations.DeleteAsync(updatedInvitation.Id);
        }
    }
}
