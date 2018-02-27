namespace Taviloglu.Wrike.ApiClient.Samples
{

    class Program
    {
        static void Main(string[] args)
        {
            var bearerToken = "2KFHNUgtdNLGJJesbN9FIkEmW31dnXXqRKiQIxy0jcQfPPvQ0WLdabhM2p2hMa7F-N-WFIUKC";
            var wrikeClient = new WrikeClient(bearerToken);

            //ColorSamples.Run(wrikeClient).Wait();

            //VersionSamples.Run(wrikeClient).Wait();

            //WebHooksSamples.Run(wrikeClient).Wait();

            //ContactsSamples.Run(wrikeClient).Wait();

            //TasksSamples.Run(wrikeClient).Wait();

            //BookAndAdWorkflow.Run(wrikeClient).Wait();

            //try other samples...

            AttachmentsSamples.Run(wrikeClient).Wait();
        }
    }
}
