using System;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Timelogs;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class TimelogSamples
    {
        public static async Task Run(WrikeClient client)
        {
            //Get all timelog records in all accounts.
            var timelogs = await client.Timelogs.GetAsync();

            //Get all timelog records for a task.
            //var timelogs = await client.Timelogs.GetAsync(taskId: "IEABX2HEKQGPEIPC");
            
            //Get all timelog records in the account.
            //var timelogs = await client.Timelogs.GetAsync(accountId: "IEABX2HE");

            //Get all timelog records in the account by createdDate
            //var timelogs = await client.Timelogs.GetAsync(
            //    accountId: "IEABX2HE", 
            //    createdDate: new WrikeDateFilterRange(new DateTime(2018, 1, 29), new DateTime(2018, 1, 30)));

            //var timelog = await client.Timelogs.GetAsync(timelogId: "IEABX2HEJQAAKOKI");

            /*
            var newTimelog = new WrikeTimelog("IEABX2HEKQGGVPW3", "comment test", 0.5m, DateTime.Now);
            newTimelog = await client.Timelogs.CreateAsync(newTimelog);

            var updatedTimelog = await client.Timelogs.UpdateAsync(newTimelog.Id, comment: "updated comment");

            await client.Timelogs.DeleteAsync(newTimelog.Id);
            */

        }
    }
}
