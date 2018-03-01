namespace Taviloglu.Wrike.ApiClient.Samples
{

    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "YYa4WIIQlhgKs5zwUBvHKcCrO8UM0uRahdgRlDPSTSBLTuOSPDQJVnA99OxiDpyZ-N-WFIUKC";
          
            var wrikeClient = new WrikeClient(bearerToken);

            //ColorSamples.Run(wrikeClient).Wait();

            //VersionSamples.Run(wrikeClient).Wait();

            WebHooksSamples.Run(wrikeClient).Wait();

            //ContactsSamples.Run(wrikeClient).Wait();

            //TasksSamples.Run(wrikeClient).Wait();

            //try other samples...

            //AttachmentsSamples.Run(wrikeClient).Wait();
        }
    }
}
