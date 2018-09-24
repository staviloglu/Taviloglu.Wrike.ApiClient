using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeMetadataTests
    {

        [Test]
        public void Ctor_WhenKeyNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeMetadata(null, "value"));
            Assert.AreEqual("key", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenKeyEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeMetadata(string.Empty, "value"));
            Assert.AreEqual("key", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenKeyMoreThanOrEqualToFiftyCharacters_ThrowArgumentException()
        {
            var keyCharacters = new List<char>();
            for (int i = 0; i < 51; i++)
            {
                keyCharacters.Add('a');
            }
            var key = new string(keyCharacters.ToArray());

            var ex = Assert.Throws<ArgumentException>(() => new WrikeMetadata(key, "value"));
            Assert.AreEqual("key", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value must be less than 50 characters"));
        }

        [Test]
        public void Ctor_WhenKeyDoesNotMatchRegEx_ThrowArgumentException()
        {
            var key = "üğ*/,.+$#";

            var ex = Assert.Throws<ArgumentException>(() => new WrikeMetadata(key, "value"));
            Assert.AreEqual("key", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("key must match ([A-Za-z0-9_-]+)"));
        }

        [Test]
        public void Ctor_WhenValueNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeMetadata("key", null));
            Assert.AreEqual("value", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenValueEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeMetadata("key", string.Empty));
            Assert.AreEqual("value", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenValueMoreThanOrEqualToThousandCharacters_ThrowArgumentException()
        {
            var valueCharacters = new List<char>();
            for (int i = 0; i < 1000; i++)
            {
                valueCharacters.Add('a');
            }
            var value = new string(valueCharacters.ToArray());

            var ex = Assert.Throws<ArgumentException>(() => new WrikeMetadata("key", value));
            Assert.AreEqual("value", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value must be less than 1000 characters"));
        }


    }
}
