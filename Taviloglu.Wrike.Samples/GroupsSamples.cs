using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient;

namespace Taviloglu.Wrike.Samples
{
    public static class GroupsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            await client.Groups.DeleteAsync("groupId", true);

            await client.Groups.DeleteAsync("groupId");
        }
    }
}
