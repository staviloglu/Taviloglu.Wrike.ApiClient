using System;
using System.Collections.Generic;
using Taviloglu.Wrike.ApiClient.Dto.Authorization;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public class AuthorizationSamples
    {
        static string AuthorizationCode = string.Empty;

        const string PermanentToken = "eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow";

        const string ClientSecret = "dbFqkiRDLLiI5jnMsYd4QlokyBsQZuO9CPylsBV0in0UgKazkojeh7GdtNhsVnxq";

        const string ClientId = "SRGi6qTT";

        public static void RunAuthorizationCodes()
        {
            var authorizationUrl = WrikeClient.GetAuthorizationUrl(
                "SRGi6qTT",
                redirectUri: "http://localhost",
                state: "myTestState",
                scope: new List<string> { WrikeScopes.Default, WrikeScopes.wsReadWrite });

            //Use this url Wrike redirect to the provided redirectUri with the Authorization code 
            //go on authorization process with that code
            
            AuthorizationCode = "UsNrpHoFexXtqI26i2sVWX68W7JANS9iTdWU7tCSVm7GfJdfZuS4VdjTZRTzvqVg-NW";

            //GettingAndRefreshingTokenDoneByUser();

            GettingAndRefreshingTokenDoneByWrikeClient();

            //PermanentTokenUsage();
        }

        private static void PermanentTokenUsage()
        {
            var wrikeClient = new WrikeClient(PermanentToken);

            var colors = wrikeClient.Colors.GetAsync().Result;
        }

        private static void GettingAndRefreshingTokenDoneByWrikeClient()
        {
            //TODO: why we need redirectUri?

            var wrikeClient = new WrikeClient(new WrikeAccessTokenRequest(
                ClientId,
                ClientSecret,
                AuthorizationCode), "http://localhost");

            var colors = wrikeClient.Colors.GetAsync().Result;

            wrikeClient.RefreshToken();

            colors = wrikeClient.Colors.GetAsync().Result;
        }

        private static void GettingAndRefreshingTokenDoneByUser()
        {
            //not recommended :)

            //TODO: why we need redirectUri?
            var accesTokenResponse = WrikeClient.GetAccesToken(new WrikeAccessTokenRequest(
                ClientId,
                ClientSecret,
                AuthorizationCode), "http://localhost");

            var wrikeClient = new WrikeClient(accesTokenResponse.AccessToken, accesTokenResponse.Host);

            var colors = wrikeClient.Colors.GetAsync().Result;

            var refreshTokenResponse = WrikeClient.RefreshToken(ClientId, ClientSecret, 
                accesTokenResponse.RefreshToken, accesTokenResponse.Host);

            wrikeClient = new WrikeClient(refreshTokenResponse.AccessToken, accesTokenResponse.Host);

            colors = wrikeClient.Colors.GetAsync().Result;
        }
    }
}
