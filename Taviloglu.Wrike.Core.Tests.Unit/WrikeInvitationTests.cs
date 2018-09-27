using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Invitations;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeInvitationTests
    {
        [Test]
        public void Ctor_WhenEmailEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeInvitation(string.Empty));
            Assert.AreEqual("email", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenEmailNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeInvitation(null));
            Assert.AreEqual("email", ex.ParamName);
        }
    }
}
