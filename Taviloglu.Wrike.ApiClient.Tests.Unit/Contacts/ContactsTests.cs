using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Contacts
{
    [TestFixture]
    public class ContactsTests
    {
        [Test]
        public void ContactsProperty_ShouldReturnContactsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeContactsClient), TestConstants.WrikeClient.Contacts);
        }        

        [Test]
        [TestCaseSource(typeof(TestConstants), "StringListParameterCanNotBeNullOrEmptyAndCanNotHaveMoreThanHundredItems")]
        public void GetAsyncWithIds_Throws<T>(T argumentException, List<string> ids) where T : ArgumentException
        {
            
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Contacts.GetAsync(ids));
        }

        [Test]
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void UpdateAsync_Throws<T>(T argumentException, string id) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Contacts.UpdateAsync(id));
        }

        
    }

}


