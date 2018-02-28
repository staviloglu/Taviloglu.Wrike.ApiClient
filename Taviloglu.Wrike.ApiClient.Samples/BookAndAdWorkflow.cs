using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Extensions;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class BookAndAdWorkflow
    {
        private static string MiraculousTaskId;
        private const string  MiraculousDirectoryPath = @"C:\Users\Sinan\Desktop\downloadedAttachments";
        public static async Task Run(WrikeClient client)
        {
            //TODO: önceden buId yi kaydetmiş de olabiliriz, email ile bulabiliriz de...
            var trashCanUserId = await GetTrashCanUserId(client, "staviloglu@gmail.com");

            //TODO: bunu da daha önceden kaydetmiş olabiliriz, ya da bir şekilde folder listeleyip alacağız, ya da sabit bir adı olan folderId yi arayıp bulacağız.
            string folderId = "IEABX2HEI4GMN53E";
            string rootFolderId = "IEABX2HEI7777777";

            //TODO: bizde bir campaign oluştuğunda wriketa trashcan rolune task ataması yaparken çalıştırılacak
            await CreateCampaignTask(client, rootFolderId, folderId, trashCanUserId);

            //TODO: trashcan gerekli operasyonları yapıp, taskın statusu güncellediğinde bize taskId gelecek ve bu çalıştırılacak
            await AssignMostAwailableUserToTask(client, folderId, trashCanUserId, MiraculousTaskId);

            //TODO: task tamamlanıp statusu güncellenince bize taskId gelecek onunla Attachmentlarını download edeceğiz.
            await DownloadAttachmentsOfTheTask(client, MiraculousTaskId);
        }

        public async static Task DownloadAttachmentsOfTheTask(WrikeClient client, string mainTaskId)
        {
            var subTasks = await client.Tasks.GetSubTasksBySuperTaskIdAsync(mainTaskId);
            foreach (var subTask in subTasks)
            {
                var attachments = await client.Attachments.GetAsync(taskId: subTask.Id, withUrls: true);
                foreach (var attachment in attachments)
                {
                    var savePath = Path.Combine(MiraculousDirectoryPath, attachment.Name);
                    await client.Attachments.DownloadAndSaveAttachment(attachment.Id, savePath);
                }
            }

        }

        public static WrikeTask GetSubTask(string title, string description, string superTaskId, string trashCanUserId)
        {
            return new WrikeTask
            {
                Title = title,
                Description = description,
                ResponsibleIds = new List<string> { trashCanUserId },
                SuperTaskIds = new List<string> { superTaskId }
            };
        }

        public async static Task<string> GetTrashCanUserId(WrikeClient client, string email)
        {
            var trashCanUser = await client.Contacts.GetContactByEmailAsync(email);

            if (trashCanUser == null)
            {
                throw new Exception("TrashCanUser not found");
            }

            return trashCanUser.Id;
        }

        public static WrikeTask GetSuperTask(string responsibleUserId, string associateName, string associateEmail,
            string associatePhoneNumber,
            string companyRealName,
            string billingAddress,
            string offerName,
            string offerDueDates,
            string contacts,
            string offerNotes,
            string offerId)
        {
            var description =
                $"Company: {companyRealName}<br/>Assoc.: {associateName}<br/>Assoc. Email: {associateEmail}<br/>Assoc. Phone: {associatePhoneNumber}<br/>Contacts: {contacts}<br/>Billing Address: {billingAddress}<br/>Notes: {offerNotes}";

            //TODO: duedates değerlerini de kullanalalım mı task için set edebiliriz?

            string offerIdCustomFieldId = "IEABX2HEJUAAUBEA";

            return new WrikeTask
            {
                Title = offerName,
                Description = description,
                ResponsibleIds = new List<string> { responsibleUserId },
                CustomFields = new List<WrikeCustomFieldData> { new WrikeCustomFieldData(offerIdCustomFieldId, offerId) }
            };
        }

        public async static Task CreateCampaignTask(WrikeClient client, string rootFolderId, string folderId, string trashCanUserId)
        {
            var superTask = GetSuperTask(trashCanUserId,
                "Associate #1", "associate@associate.com",
                "0090 539 490 7580",
                "Company real name",
                "Maslak Gazeteciler Sitesi B3 Blok D:20 34457 Sariyer Istanbul Turkey",
                "Offer Name #1",
                "26.02.2018 - 02.04.2018",
                "Contacts...",
                "Special notes about offer",
                "12854");


            //mainTaskı yaratırken içinde bulunacağı folderı veriyoruz
            superTask = await client.Tasks.CreateAsync(folderId, superTask);

            MiraculousTaskId = superTask.Id;

            //her productiondan bir subTask yarat
            var subTasks = new List<WrikeTask>
            {
                GetSubTask("Production 1", "1920x1080 | mpeg4 | 15sec", superTask.Id, trashCanUserId ),
                GetSubTask("Production 2", "1920x1080 | flv | 15sec", superTask.Id, trashCanUserId ),
                GetSubTask("Production 3", "1920x1080 | jpg ", superTask.Id, trashCanUserId )
            };

            foreach (var subTask in subTasks)
            {
                //maintaskın subtasklarını yaratırken rootFolderId Veriyoruz
                var createdTask = await client.Tasks.CreateAsync(rootFolderId, subTask);
            }
        }

        public static string GetUserIdWithMinimumWorkload(List<WrikeTask> taskList, List<string> userList, bool countSubTasks)
        {
            //TODO: her user için bütün taskları tekrar geziyor, bunun yerine taskları gezip userlara count atama yapmak daha iyi olabilir.
            int usersWorkload = 0;
            int minWorkload = int.MaxValue;
            string userIdToAssign = string.Empty;
            foreach (var userId in userList)
            {
                usersWorkload = 0;
                foreach (var task in taskList)
                {
                    if (task.ResponsibleIds.Count < 1
                        || !task.ResponsibleIds.Any(id => id.Equals(userId))) continue;

                    if (countSubTasks)
                    {
                        usersWorkload += task.SubTaskIds.Count;
                    }
                    else
                    {
                        usersWorkload++;
                    }                    
                }

                if (usersWorkload < minWorkload)
                {
                    userIdToAssign = userId;
                    minWorkload = usersWorkload;
                }
            }

            return userIdToAssign;
        }

        public async static Task AssignMostAwailableUserToTask(WrikeClient client, string folderId, string trashCanUserId, string taskId)
        {
            //TODO:
            //iş yükü oluşturacak statuste olan taskların tamamını getir, filtrelemeler yapılacak
            var taskList = await client.Tasks.GetAsync(folderId: folderId, fields: new List<string> { WrikeTask.OptionalFields.ResponsibleIds, WrikeTask.OptionalFields.SubTaskIds, WrikeTask.OptionalFields.SuperTaskIds });

            if (taskList.Count>0)
            {
                //TODO:
                //task ataması yapılabilecek UserId listesi önceden girilmiş olabilir
                //wriketaki userlar çekilip trashcan olmayanların tamamı diye kabul edilebilir

                //TODO: accounta bağlı ne kadar person tipinde user varsa al, bu kişiler özel bir account ile de ayrılabilir.
                //ya da id leri önceden biliniyor olabilir.
                var userList = await client.Contacts.GetContactsByTypeAsync(WrikeUserType.Person);
                var userIds = userList.Select(u => u.Id).ToList();

                var userId = GetUserIdWithMinimumWorkload(taskList, userIds, true); //most available user to assign the task

                var customStatusId = "IEABX2HEJMAIOJKE"; //customStatusId to move the task (Assigned List)

                

                //ilgili taskı trashCan rolunden al bulduğun usera assign et ve ilgili customStatuse çek
                var updatedTask = await client.Tasks.UpdateAsync(
                    taskId,
                    removeResponsibles: new List<string> { trashCanUserId },
                    addResponsibles: new List<string> { userId },
                    customStatus: customStatusId); 
            }
        }
    }
}
