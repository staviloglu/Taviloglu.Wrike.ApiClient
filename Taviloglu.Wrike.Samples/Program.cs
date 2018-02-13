namespace Taviloglu.Wrike.ApiClient.Samples
{

    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "your-permanent-token";
            var wrikeClient = new WrikeClient(bearerToken);

            ColorSamples.Run(wrikeClient).Wait();

            VersionSamples.Run(wrikeClient).Wait();

            WebHooksSamples.Run(wrikeClient).Wait();

            //try other samples...
        }
    }
}
