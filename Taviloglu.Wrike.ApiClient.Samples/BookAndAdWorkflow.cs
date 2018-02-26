using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Extensions;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class BookAndAdWorkflow
    {
        public static async Task Run(WrikeClient client)
        {
            //get trashcanuser
            var trashCanUser = await client.Contacts.GetByEmailAsync("staviloglu@gmail.com");

            if (trashCanUser==null)
            {
                throw new Exception("TrashCanUser not found");
            }

            //eğer contactId yi saklarsak database de bu şekilde de alabiliriz
            //var trashcanUser1 = await client.Users.GetAsync("KUADWLD7")



        }
    }
}
