using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit
{
    public static class TestConstants
    {
        public static ArgumentException ArgumentException = new ArgumentException();

        public static ArgumentNullException ArgumentNullException = new ArgumentNullException();

        public static WrikeClient WrikeClient = new WrikeClient("");

        public static object[] SrtingParameterCanNotBeNullOrEmpty =
        {
            new object[] { ArgumentException, string.Empty },
            new object[] { ArgumentNullException, null }
        };

        public static object[] StringListParameterCanNotBeNullOrEmptyAndCanNotHaveMoreThanHundredItems =
        {
            new object[] { ArgumentException, new List<string>() },
            new object[] { ArgumentNullException, null },
            new object[] { ArgumentException, ListOfStringWithMoreThanHundredItems() },
        };

        public static object[] StringListParameterCanNotBeNullOrEmpty =
       {
            new object[] { ArgumentException, new List<string>() },
            new object[] { ArgumentNullException, null }
        };

        public static List<string> ListOfStringWithMoreThanHundredItems()
        {
            var retVal = new List<string>();

            for (int i = 0; i < 101; i++) { retVal.Add("id"); }

            return retVal;
        }
    }
}
