using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Extensions;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class BookAndAdWorkflow
    {
        public static async Task Run(WrikeClient client)
        {
            //TODO: önceden buId yi kaydetmiş de olabiliriz, email ile bulabiliriz de...
            var trashCanUserId = await GetTrashCanUserId(client, "staviloglu@gmail.com");

            //TODO: bunu da daha önceden kaydetmiş olabiliriz, ya da bir şekilde folder listeleyip alacağız, ya da sabit bir adı olan folderId yi arayıp bulacağız.
            string folderId = "IEABX2HEI4GMN53E";

            //TODO: bizde bir campaign oluştuğunda wriketa trashcan rolune task ataması yaparken çalıştırılacak
            await CreateCampaignTask(client, folderId, trashCanUserId);

            //TODO: trashcan gerekli operasyonları yapıp, taskın statusu güncellediğinde bize taskId gelecek ve bu çalıştırılacak
            await AssignMostAwailableUserToTask(client, folderId, trashCanUserId, "taskId");

            //TODO: task tamamlanıp statusu güncellenince bize taskId gelecek onunla Attachmentlarını download edeceğiz.
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
            var trashCanUser = await client.Contacts.GetByEmailAsync(email);

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
            string offerNotes)
        {
            var description =
                $"Company: {companyRealName}<br/>Assoc.: {associateName}<br/>Assoc. Email: {associateEmail}<br/>Assoc. Phone: {associatePhoneNumber}<br/>Contacts: {contacts}<br/>Billing Address: {billingAddress}<br/>Notes: {offerNotes}";

            //TODO: duedates değerlerini de kullanalalım mı task için set edebiliriz?

            return new WrikeTask
            {
                Title = offerName,
                Description = description,
                ResponsibleIds = new List<string> { responsibleUserId }
            };
        }

        public async static Task CreateCampaignTask(WrikeClient client, string folderId, string trashCanUserId)
        {
            var superTask = GetSuperTask(trashCanUserId,
                "Associate #1", "associate@associate.com",
                "0090 539 490 7580",
                "Company real name",
                "Maslak Gazeteciler Sitesi B3 Blok D:20 34457 Sariyer Istanbul Turkey",
                "Offer Name #1",
                "26.02.2018 - 02.04.2018",
                "Contacts...",
                "Special notes about offer");

            superTask = await client.Tasks.CreateAsync(folderId, superTask);

            //her productiondan bir subTask yarat
            var subTasks = new List<WrikeTask>
            {
                GetSubTask("Production 1", "1920x1080 | mpeg4 | 15sec", superTask.Id, trashCanUserId ),
                GetSubTask("Production 2", "1920x1080 | flv | 15sec", superTask.Id, trashCanUserId ),
                GetSubTask("Production 3", "1920x1080 | jpg ", superTask.Id, trashCanUserId )
            };

            foreach (var subTask in subTasks)
            {
                var createdTask = await client.Tasks.CreateAsync(folderId, subTask);
            }
        }

        public static string GetUserIdWithMinimumTaskCount(List<WrikeTask> taskList, List<string> userList)
        {
            //TODO: her user için bütün taskları tekrar geziyor, bunun yerine taskları gezip userlara count atama yapmak daha iyi olabilir.
            int taskCount = 0;
            int minTaskCount = int.MaxValue;
            string userIdToAssign = string.Empty;
            foreach (var userId in userList)
            {
                taskCount = 0;
                foreach (var task in taskList)
                {
                    if (task.ResponsibleIds.Count < 1
                        || !task.ResponsibleIds.Any(id => id.Equals(userId))) continue;

                    taskCount++;
                }

                if (taskCount < minTaskCount)
                {
                    userIdToAssign = userId;
                    minTaskCount = taskCount;
                }
            }

            return userIdToAssign;
        }

        public async static Task AssignMostAwailableUserToTask(WrikeClient client, string folderId, string trashCanUserId, string taskId)
        {
            //TODO:
            //iş yükü oluşturacak statuste olan taskların tamamını getir, filtrelemeler yapılacak
            var taskList = await client.Tasks.GetAsync(folderId: folderId, fields: new List<string> { WrikeTask.OptionalFields.ResponsibleIds, WrikeTask.OptionalFields.SubTaskIds, WrikeTask.OptionalFields.SuperTaskIds });

            //TODO:
            //task ataması yapılabilecek UserId listesi önceden girilmiş olabilir
            //wriketaki userlar çekilip trashcan olmayanların tamamı diye kabul edilebilir

            var userIds = taskList
                .Where(t => t.ResponsibleIds.Count > 0)
                .SelectMany(t => t.ResponsibleIds).Distinct().ToList();

            var userId = GetUserIdWithMinimumTaskCount(taskList, userIds); //mot available user to assign the task

            var customStatusId = "IEABR5PBJMAAAAAB"; //customStatusId to move the task

            //ilgili taskı trashCan rolunden al bulduğun usera assign et ve ilgili customStatuse çek
            var updatedTask = await client.Tasks.UpdateAsync(
                taskId,
                removeResponsibles: new List<string> { trashCanUserId },
                addResponsibles: new List<string> { userId },
                customStatus: customStatusId);
        }
    }
}
