using NUnit.Framework;
using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Invitations
{
    [TestFixture]
    public class InvitationTests
    {
        readonly List<string> DefaultInvitationIds = new List<string> { "IEACGXLUJEAFESOS", "IEACGXLUJEAFESOO" };

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var existingInvitations = WrikeClientFactory.GetWrikeClient().Invitations.GetAsync().Result;

            foreach (var invitation in existingInvitations)
            {
                if (!DefaultInvitationIds.Contains(invitation.Id))
                {
                    WrikeClientFactory.GetWrikeClient().Invitations.DeleteAsync(invitation.Id).Wait();
                }
            }
        }

        [Test]
        public void GetAsync_ShouldReturnDefaultGroup()
        {
            var invitations = WrikeClientFactory.GetWrikeClient().Invitations.GetAsync().Result;
            Assert.IsNotNull(invitations);
            Assert.GreaterOrEqual(invitations.Count, 2);
        }

        // TODO: free accounts are not able run below commands

        /*
        [Test]
        public void CreateAsync_ShouldAddNewGroupWithTitle()
        {
            var newInvitation = new WrikeInvitation(email: "thomas.anderson@whatisthematrix.com"
                , firstName: "Thomas", lastName: "Anderson", role: WrikeUserRole.User);

            var createdInvitation = WrikeClientFactory.GetWrikeClient()
                .Invitations.CreateAsync(newInvitation, "What is the matrix?", "Follow the wtihe rabbit!").Result;

            Assert.IsNotNull(createdInvitation);
            Assert.AreEqual(newInvitation.Email, createdInvitation.Email);
            Assert.AreEqual(newInvitation.FirstName, createdInvitation.FirstName);
            Assert.AreEqual(newInvitation.LastName, createdInvitation.LastName);
            Assert.AreEqual(newInvitation.Role, createdInvitation.Role);
            Assert.AreEqual(newInvitation.External, createdInvitation.External);

            //TODO: test other parameters
        }
        
        [Test]
        public void UpdateAsync_ShouldUpdateGroupTitle()
        {
            var newInvitation = new WrikeInvitation(email: "trinity@whatisthematrix.com"
                , firstName: "Trinity", role: WrikeUserRole.User);

            newInvitation = WrikeClientFactory.GetWrikeClient()
                .Invitations.CreateAsync(newInvitation, "We’ve done it, Trinity", "We’ve found him.").Result;

            var updatedGroup = WrikeClientFactory.GetWrikeClient().Invitations.UpdateAsync(newInvitation.Id, role: WrikeUserRole.Collaborator, external: true).Result;

            Assert.IsNotNull(updatedGroup);
            Assert.AreEqual(newInvitation.Role, updatedGroup.Role);
            Assert.AreEqual(newInvitation.External, updatedGroup.External);
        }




        [Test]
        public void DeleteAsync_ShouldDeleteNewGroup()
        {
            var newInvitation = new WrikeInvitation(email: "cypher@whatisthematrix.com"
                , firstName: "Cypher");

            newInvitation = WrikeClientFactory.GetWrikeClient()
                .Invitations.CreateAsync(newInvitation, "Do we have a deal, Mr. Reagan?", "Whatever you want, Mr. Reagan.").Result;

            WrikeClientFactory.GetWrikeClient().Invitations.DeleteAsync(newInvitation.Id).Wait();

            var invitations = WrikeClientFactory.GetWrikeClient().Invitations.GetAsync().Result;
            var isInvitationDeleted = !invitations.Any(i => i.Id == newInvitation.Id);

            Assert.IsTrue(isInvitationDeleted);
        }
        */
    }
}
