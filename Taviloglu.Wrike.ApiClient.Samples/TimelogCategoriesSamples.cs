using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class TimelogCategoriesSamples
    {
        public static async Task Run(WrikeClient client)
        {
            //Get all timelog categorie in the account.
            var timelogCategories = await client.TimeLogCategories.GetAsync();
        }
    }
}

