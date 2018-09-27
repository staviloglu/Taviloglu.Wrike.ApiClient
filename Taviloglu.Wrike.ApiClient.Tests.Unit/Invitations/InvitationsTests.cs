using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Invitations;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Invitations
{
    [TestFixture]
    public class InvitationsTests
    {
        [Test]
        public void InvitationsProperty_ShouldReturnInvitationsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeInvitationsClient), TestConstants.WrikeClient.Invitations);
        }

        [Test]
        public void CreateAsync_NewInvitationNull_ThrowArgumentNullException()
        {
            WrikeInvitation newInvitation = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Invitations
            .CreateAsync(newInvitation));
            Assert.AreEqual("newInvitation", ex.ParamName);
        }
    }
}
