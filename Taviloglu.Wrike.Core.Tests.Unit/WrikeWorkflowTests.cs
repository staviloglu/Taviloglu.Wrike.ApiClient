using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Workflows;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeWrokflowTests
    {
        [Test]
        public void Ctor_WhenNameEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeWorkflow(string.Empty));
            Assert.AreEqual("name", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenNameeNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeWorkflow(null));
            Assert.AreEqual("name", ex.ParamName);
        }
    }
}
