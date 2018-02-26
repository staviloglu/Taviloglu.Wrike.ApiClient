namespace Taviloglu.Wrike.ApiClient.Samples
{

    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "your-token";
            var wrikeClient = new WrikeClient(bearerToken);

            ColorSamples.Run(wrikeClient).Wait();

            //VersionSamples.Run(wrikeClient).Wait();

            //WebHooksSamples.Run(wrikeClient).Wait();

            //ContactsSamples.Run(wrikeClient).Wait();

            //TasksSamples.Run(wrikeClient).Wait();

            //BookAndAdWorkflow.Run(wrikeClient).Wait();

            WorkflowSamples.Run(wrikeClient).Wait();

            //try other samples...
        }
    }
}
