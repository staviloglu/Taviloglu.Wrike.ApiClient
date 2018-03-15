namespace Taviloglu.Wrike.ApiClient.Samples
{

    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "CUEr3ihGqPktpO7MuWF1q5hYSUIFZSeIPdXgV86WBj50EJv6IIl1YF5kpZ6UOLVj-N-WFIUKC";
          
            var wrikeClient = new WrikeClient(bearerToken);

            //ColorSamples.Run(wrikeClient).Wait();

            //VersionSamples.Run(wrikeClient).Wait();

            //WebHooksSamples.Run(wrikeClient).Wait();

            //CommentsSamples.Run(wrikeClient).Wait();

            //FoldersAndProjectsSamples.Run(wrikeClient).Wait();

            //TimelogSamples.Run(wrikeClient).Wait();

            //ContactsSamples.Run(wrikeClient).Wait();

            //TasksSamples.Run(wrikeClient).Wait();

            WorkflowSamples.Run(wrikeClient).Wait();

            //try other samples...

            //AttachmentsSamples.Run(wrikeClient).Wait();
        }
    }
}
