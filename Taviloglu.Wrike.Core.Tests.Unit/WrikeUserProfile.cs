using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeUserProfileTest
    {
        [Test]
        public void Ctor_AccountIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeUserProfile(null, WrikeUserRole.User));
            Assert.AreEqual("accountId", ex.ParamName);
        }
    }
}
