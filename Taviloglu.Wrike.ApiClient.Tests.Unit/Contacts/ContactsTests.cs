using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Contacts
{
    [TestFixture]
    public class ContactsTests
    {
        WrikeClient _wrikeClient;

        [OneTimeSetUp]
        public void Setup()
        {
            _wrikeClient = new WrikeClient("eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow");
        }

        [Test]
        public void ContactsProperty_ShouldReturnContactsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeContactsClient), _wrikeClient.Contacts);
        }

        [Test]
        public void GetAsync_ContactIdsMoreThanHundred_ThrowArgumentException()
        {
            var contactIds = new List<string>();
            for (int i = 0; i < 101; i++)
            {
                contactIds.Add($"contactId {i}");
            }

            Assert.ThrowsAsync<ArgumentException>(() => _wrikeClient.Contacts.GetAsync(contactIds));
        }

        [Test]
        public void GetAsync_ContactIdsEmpty_ThrowArgumentNullException()
        {
            var contactIds = new List<string>();

            Assert.ThrowsAsync<ArgumentNullException>(() => _wrikeClient.Contacts.GetAsync(contactIds));
        }

        [Test]
        public void GetAsync_ContactIdsNull_ThrowArgumentNullException()
        {
            var contactIds = new List<string>();

            Assert.ThrowsAsync<ArgumentNullException>(() => _wrikeClient.Contacts.GetAsync(contactIds));
        }

        [Test]
        public void UpdateAsync_IdNull_ThrowArgumentNullException()
        {
            var contactIds = new List<string>();

            Assert.ThrowsAsync<ArgumentNullException>(() => _wrikeClient.Contacts.UpdateAsync(null));
        }
    }
}


