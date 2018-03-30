namespace Taviloglu.Wrike.ApiClient.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "your-api-token";

            var wrikeClient = new WrikeClient(bearerToken);

            //ColorSamples.Run(wrikeClient).Wait();

            //VersionSamples.Run(wrikeClient).Wait();

            //WebHooksSamples.Run(wrikeClient).Wait();

            //CommentsSamples.Run(wrikeClient).Wait();

            //FoldersAndProjectsSamples.Run(wrikeClient).Wait();

            //TimelogSamples.Run(wrikeClient).Wait();

            //ContactsSamples.Run(wrikeClient).Wait();

            //TasksSamples.Run(wrikeClient).Wait();

            //WorkflowSamples.Run(wrikeClient).Wait();

            GroupsSamples.Run(wrikeClient).Wait();

            //InvitationsSamples.Run(wrikeClient).Wait();

            //try other samples...

            //AttachmentsSamples.Run(wrikeClient).Wait();
        }
    }
}
