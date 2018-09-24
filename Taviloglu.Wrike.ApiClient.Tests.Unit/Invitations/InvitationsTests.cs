using NUnit.Framework;
using System;

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
    }
}
