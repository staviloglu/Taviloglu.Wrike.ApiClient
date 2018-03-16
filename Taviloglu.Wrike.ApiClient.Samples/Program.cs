namespace Taviloglu.Wrike.ApiClient.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "vnxAfRNCoxh5O4J1pdchJLKW8XpvdSmnO0pHwCJd0oM2wBzog8SlEgnVVKAQyJ5r-N-WFIUKC";

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

            InvitationsSamples.Run(wrikeClient).Wait();

            //try other samples...

            //AttachmentsSamples.Run(wrikeClient).Wait();
        }
    }
}
