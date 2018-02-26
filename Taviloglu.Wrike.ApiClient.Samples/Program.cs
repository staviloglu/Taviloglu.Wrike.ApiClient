namespace Taviloglu.Wrike.ApiClient.Samples
{

    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "4D0FVeU6TQa1JUnFewQFD3KOE6VlSyMlcEEtlypzhwMW1qZ2bPcEbbV9GXA6g2Tt-N-WFIUKC";
            var wrikeClient = new WrikeClient(bearerToken);

            //ColorSamples.Run(wrikeClient).Wait();

            //VersionSamples.Run(wrikeClient).Wait();

            //WebHooksSamples.Run(wrikeClient).Wait();

            //ContactsSamples.Run(wrikeClient).Wait();

            //TasksSamples.Run(wrikeClient).Wait();

            BookAndAdWorkflow.Run(wrikeClient).Wait();

            //try other samples...
        }
    }
}
