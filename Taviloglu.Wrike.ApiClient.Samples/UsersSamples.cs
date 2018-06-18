using System;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class UsersSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var user = await client.Users.GetAsync("userId");



            user.Profiles[0].Role = Core.WrikeUserRole.User;
            user.Profiles[0].External = true;

            user = await client.Users.UpdateAsync(user.Id, user.Profiles[0]);
        }
    }
}
