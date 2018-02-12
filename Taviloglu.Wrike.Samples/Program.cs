using Taviloglu.Wrike.ApiClient;

namespace Taviloglu.Wrike.Samples
{

    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "your-permanent-token";
            var wrikeClient = new WrikeClient(bearerToken);
            
            ColorSamples.Run(wrikeClient).Wait();

            VersionSamples.Run(wrikeClient).Wait();

            WebhooksSamples.Run(wrikeClient).Wait();

            //try other samples...
        }
    }
}
