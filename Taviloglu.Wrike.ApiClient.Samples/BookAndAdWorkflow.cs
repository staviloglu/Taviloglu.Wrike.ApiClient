using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Extensions;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class BookAndAdWorkflow
    {
        public static async Task Run(WrikeClient client)
        {
            //get trashcanuser
            var trashCanUser = await client.Contacts.GetByEmailAsync("staviloglu@gmail.com");

            if (trashCanUser == null)
            {
                throw new Exception("TrashCanUser not found");
            }

            //eğer contactId yi saklarsak database de bu şekilde de alabiliriz
            //var trashcanUser1 = await client.Users.GetAsync("KUADWLD7")

            string folderId = "IEABR5PBI4GOFN3F";

            await CreateCampaignTask(client, folderId, trashCanUser.Id);
        }

        public static WrikeTask GetSubTask(string title, string description, string superTaskId, string responsibleUserId)
        {
            return new WrikeTask
            {
                Title = title,
                Description = description,
                ResponsibleIds = new List<string> { responsibleUserId },
                SuperTaskIds = new List<string> { superTaskId }
            };
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
                $"Company: {companyRealName}\nAssoc.: {associateName}\nAssoc. Email: {associateEmail}\nAssoc. Phone: {associatePhoneNumber}\nContacts: {contacts}\nBilling Address: {billingAddress}\nNotes: {offerNotes}";

            //TODO: try to use duedates?

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
    }
}
