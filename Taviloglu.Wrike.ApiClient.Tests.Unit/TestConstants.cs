using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit
{
    public static class TestConstants
    {
        public static WrikeClient WrikeClient = new WrikeClient("bearerToken");       

        public static List<string> ListOfStringWithMoreThanHundredItems()
        {
            var retVal = new List<string>();

            for (int i = 0; i < 101; i++) { retVal.Add("id"); }

            return retVal;
        }
    }
}
