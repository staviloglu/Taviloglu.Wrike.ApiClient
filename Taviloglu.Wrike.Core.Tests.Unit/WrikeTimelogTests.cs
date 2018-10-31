using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Timelogs;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeTimelogTests
    {
        [Test]
        public void Ctor_WhenTaskIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeTimelog(string.Empty,0,DateTime.Now));
            Assert.AreEqual("taskId", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenTitleNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeTimelog(null, 0, DateTime.Now));
            Assert.AreEqual("taskId", ex.ParamName);
        }

        //[Test]
        //public void Ctor_WhenCommentEmpty_ThrowArgumentException()
        //{
        //    var ex = Assert.Throws<ArgumentException>(() => new WrikeTimelog("taskId", string.Empty, 0, DateTime.Now));
        //    Assert.AreEqual("comment", ex.ParamName);
        //    Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        //}

        //[Test]
        //public void Ctor_WhenCommentNull_ThrowArgumentNullException()
        //{
        //    var ex = Assert.Throws<ArgumentNullException>(() => new WrikeTimelog("taskId", null, 0, DateTime.Now));
        //    Assert.AreEqual("comment", ex.ParamName);
        //}

        [Test]
        [TestCase(-1)]
        [TestCase(25)]
        public void Ctor_WhenHourNotInRange_ThrowArgumentOutOfRangeException(decimal hours)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new WrikeTimelog("taskId", hours, DateTime.Now, comment: "comment"));
            Assert.AreEqual("hours", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value must be in [0,24] range"));
        }
    }
}
