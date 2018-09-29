using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Dependencies;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    public class WrikeDependencyWithPredecessorTests
    {
        [Test]
        public void Ctor_WhenPredecessorIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeDependency(string.Empty, "successorId", WrikeDependencyRelationType.StartToStart));
            Assert.AreEqual("predecessorId", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }


        [Test]
        public void Ctor_WhenPredecessorIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeDependency(null, "successorId", WrikeDependencyRelationType.StartToStart));
            Assert.AreEqual("predecessorId", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenSuccessorIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeDependency("predecessorId", string.Empty, WrikeDependencyRelationType.StartToStart));
            Assert.AreEqual("successorId", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }


        [Test]
        public void Ctor_WhenSuccessorIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeDependency("predecessorId", null, WrikeDependencyRelationType.StartToStart));
            Assert.AreEqual("successorId", ex.ParamName);
        }

    }
}
