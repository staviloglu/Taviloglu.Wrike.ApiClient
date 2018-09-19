using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class GroupsSamples
    {
        public static async Task Run(WrikeClient client)
        {

            var allGroups = await client.Groups.GetAsync();

            var newGroup = new WrikeGroup("Sinan's Test Group");
            newGroup = await client.Groups.CreateAsync(newGroup);



            var updatedGroup = await client.Groups.UpdateAsync(
                newGroup.Id, 
                title: "Sinan's Group [Updated]", 
                avatar: new WrikeGroupAvatar("#795548", "SG"));



            await client.Groups.DeleteAsync(newGroup.Id, true);

            await client.Groups.DeleteAsync(newGroup.Id);
        }
    }
}
