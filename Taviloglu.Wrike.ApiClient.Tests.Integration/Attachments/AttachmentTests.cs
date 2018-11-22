using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Attachments
{
    [TestFixture, Order(2)]
    public class AttachmentTests
    {
        const string FolderId = "IEACGXLUI4IHJMYP";
        const string TaskId = "IEACGXLUKQIGFGAK";
        
        const string DefaultFolderAttachmentId = "IEACGXLUIYCEX6BY";
        const string DefaultTaskAttachmentId = "IEACGXLUIYCEX54E";

        readonly List<string> DefaultAttachmentIds = new List<string> { DefaultFolderAttachmentId, DefaultTaskAttachmentId };
        const string DefaultAttachmentName = "wrikeLogo.png";
        const int AttachmentSize = 37361;
        const int AttachmentW44PreviewSize = 1178;


        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var attachments = WrikeClientFactory.GetWrikeClient().Attachments.GetAsync().Result;

            foreach (var attachment in attachments)
            {
                if (!DefaultAttachmentIds.Contains(attachment.Id))
                {
                    WrikeClientFactory.GetWrikeClient().Attachments.DeleteAsync(attachment.Id).Wait();
                }
            }
        }

        [Test]
        public void GetAsync_ShouldReturnTwoOrMoreAttachments()
        {
            var attachments = WrikeClientFactory.GetWrikeClient().Attachments.GetAsync().Result;
            Assert.IsNotNull(attachments);
            Assert.GreaterOrEqual(attachments.Count, 2);
        }

        [Test]
        public void GetInFolderAsync_ShouldReturnOneOrMoreAttachments()
        {
            var attachments = WrikeClientFactory.GetWrikeClient().Attachments.GetInFolderAsync(FolderId).Result;
            Assert.IsNotNull(attachments);
            Assert.GreaterOrEqual(attachments.Count, 1);
        }

        [Test]
        public void GetInTaskAsync_ShouldReturnOneOrMoreAttachments()
        {
            var attachments = WrikeClientFactory.GetWrikeClient().Attachments.GetInTaskAsync(TaskId).Result;
            Assert.IsNotNull(attachments);
            Assert.GreaterOrEqual(attachments.Count, 1);
        }

        [Test]
        public void GetAsyncWithIds_ShouldReturnDefaultAttachments()
        {
            var attachments = WrikeClientFactory.GetWrikeClient().Attachments.GetAsync(DefaultAttachmentIds).Result;

            Assert.IsNotNull(attachments);
            Assert.AreEqual(2, attachments.Count);
            Assert.IsTrue(attachments.Any(a => a.Id == DefaultTaskAttachmentId));
            Assert.IsTrue(attachments.Any(a => a.Id == DefaultFolderAttachmentId));

        }

        [Test]
        public void DownloadAsync_ShouldReturn37361Bytes()
        {
            var downloadStream = WrikeClientFactory.GetWrikeClient().Attachments.DownloadAsync(DefaultFolderAttachmentId).Result;
            Assert.IsNotNull(downloadStream);
            Assert.AreEqual(AttachmentSize, downloadStream.Length);
        }

        [Test]
        public void DownloadAsync_WhenW44_ShouldReturn1178Bytes()
        {
            var downloadStream = WrikeClientFactory.GetWrikeClient().Attachments.DownloadPreviewAsync(DefaultFolderAttachmentId, Core.Attachments.WrikePreviewDimension.w44).Result;

            Assert.IsNotNull(downloadStream);
            Assert.AreEqual(AttachmentW44PreviewSize, downloadStream.Length);
        }

        [Test]
        public void GetAccessUrlAsync_ShouldReturnUrl()
        {
            var wrikeUrl = WrikeClientFactory.GetWrikeClient().Attachments.GetAccessUrlAsync(DefaultFolderAttachmentId).Result;

            Assert.IsNotNull(wrikeUrl);
            Assert.IsTrue(wrikeUrl.Url.StartsWith("https://storage.www.wrike.com"));
        }

        [Test]
        public void CreateInFolderAsync_ShouldUploadAttachment()
        {
            var fileName = "tetFile.png";

            var newAttachment = WrikeClientFactory.GetWrikeClient().Attachments.CreateInFolderAsync(FolderId, fileName, File.ReadAllBytes("wrikeLogo.png")).Result;

            Assert.IsNotNull(newAttachment);
            Assert.AreEqual(FolderId, newAttachment.FolderId);
            Assert.AreEqual(AttachmentSize, newAttachment.Size);
            Assert.AreEqual(fileName, newAttachment.Name);
        }

        [Test]
        public void CreateInTaskAsync_ShouldUploadAttachment()
        {
            var fileName = "tetFile.png";

            var newAttachment = WrikeClientFactory.GetWrikeClient().Attachments.CreateInTaskAsync(TaskId, fileName, File.ReadAllBytes("wrikeLogo.png")).Result;

            Assert.IsNotNull(newAttachment);
            Assert.AreEqual(TaskId, newAttachment.TaskId);
            Assert.AreEqual(AttachmentSize, newAttachment.Size);
            Assert.AreEqual(fileName, newAttachment.Name);
        }

        [Test]
        public void DeleteAsync_ShouldDeleteNewAttachment()
        {
            var fileName = "tetFile.png";

            var newAttachment = WrikeClientFactory.GetWrikeClient().Attachments.CreateInFolderAsync(FolderId, fileName, File.ReadAllBytes("wrikeLogo.png")).Result;

            Assert.IsNotNull(newAttachment);
            Assert.AreEqual(FolderId, newAttachment.FolderId);
            Assert.AreEqual(AttachmentSize, newAttachment.Size);
            Assert.AreEqual(fileName, newAttachment.Name);

            WrikeClientFactory.GetWrikeClient().Attachments.DeleteAsync(newAttachment.Id).Wait();

            var attachments = WrikeClientFactory.GetWrikeClient().Attachments.GetAsync().Result;
            var isAttachmentDeleted = !attachments.Any(a => a.Id == newAttachment.Id);

            Assert.IsTrue(isAttachmentDeleted);
        }
    }
}
