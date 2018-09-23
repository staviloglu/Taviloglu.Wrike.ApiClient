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

        [Test]
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void DeleteAsync_Throws<T>(T argumentException, string id) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Invitations.DeleteAsync(id));
        }

        [Test]
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void UpdateAsync_Throws<T>(T argumentException, string id) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Invitations.UpdateAsync(id));
        }
    }
}
