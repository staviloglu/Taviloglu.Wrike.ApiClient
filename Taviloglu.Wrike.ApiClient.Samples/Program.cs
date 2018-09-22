using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>(101);
            Console.WriteLine(list.Count);


            var bearerToken = "eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow";

            var wrikeClient = new WrikeClient(bearerToken);

            //ColorSamples.Run(wrikeClient).Wait();

            //VersionSamples.Run(wrikeClient).Wait();

            //WebHooksSamples.Run(wrikeClient).Wait();

            //CommentsSamples.Run(wrikeClient).Wait();

            //AccountsSamples.Run(wrikeClient).Wait();

            //FoldersAndProjectsSamples.Run(wrikeClient).Wait();

            //TimelogSamples.Run(wrikeClient).Wait();
            //TimelogCategoriesSamples.Run(wrikeClient).Wait();

            ContactsSamples.Run(wrikeClient).Wait();

            //TasksSamples.Run(wrikeClient).Wait();

            //WorkflowSamples.Run(wrikeClient).Wait();

            //GroupsSamples.Run(wrikeClient).Wait();

            //InvitationsSamples.Run(wrikeClient).Wait();

            //CustomFieldsSamples.Run(wrikeClient).Wait();

            //UsersSamples.Run(wrikeClient).Wait();

            //try other samples...

            //AttachmentsSamples.Run(wrikeClient).Wait();
        }
    }
}
