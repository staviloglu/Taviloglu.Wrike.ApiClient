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
    }
}


