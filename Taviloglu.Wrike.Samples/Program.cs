using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient;

namespace Taviloglu.Wrike.Samples
{
    class Program
    {
        static void Main(string[] args)
        {

            MainAsync(args).Wait();
            
        }

        static async Task MainAsync(string[] args)
        {
            var bearerToken = "";
            var wrikeClient = new WrikeClient(bearerToken);

            #region Colors
            //var colors = await wrikeClient.GetColorsAsync();
            #endregion

            #region CustomFields
            //var customFields = await wrikeClient.GetCustomFieldsAsync();
            //var customFields = await wrikeClient.GetCustomFiledInfoAsync(new List<string> { "IEABX2HEJUAAREOB", "IEABX2HEJUAAREOD" });

            //TODO: returns invalid-parameter error if type is not Text
            //var updatedCustomField = await wrikeClient.UpdateCustomFieldAsync(
            //    "IEABX2HEJUAATMXD", 
            //    title: "sinanTestField3",
            //    type: WrikeCustomFieldType.Money);


            //var newCustomField = new WrikeCustomField
            //{
            //    AccountId = "IEABX2HE",
            //    Title = "Sinan Test Custom Field",
            //    Type = WrikeCustomFieldTypes.Numeric
            //};
            //var field = await wrikeClient.CreateCustomFieldAsync(newCustomField);
            #endregion

        }
    }
}
