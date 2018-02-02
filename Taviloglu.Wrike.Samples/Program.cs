using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.Samples
{
    class Program
    {
        //accountId = 1635809
        //taskId = 209337199
        //folderId = 158167125


        private const string _bearerToken = "";
        static void Main(string[] args)
        {

            MainAsync(args).Wait();
            
        }

        static async Task MainAsync(string[] args)
        {
            var wrikeClient = new WrikeClient(_bearerToken);



            var customFields = await wrikeClient.GetCustomFields();
            var updatedFildl = await wrikeClient.UpdateCustomField("IEABX2HEJUAATMXD", title: "sinanCustomField2");


            var newCustomField = new WrikeCustomField {
                AccountId = "IEABX2HE",
                Title = "Sinan Test Custom Field",
                Type = WrikeCustomFieldType.Text
            };

            var field = await wrikeClient.CreateCustomField(newCustomField);
        }
    }
}
