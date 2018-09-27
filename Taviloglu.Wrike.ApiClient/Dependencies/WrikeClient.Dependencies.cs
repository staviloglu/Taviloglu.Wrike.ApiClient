namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeDependenciesClient
    {
        public IWrikeDependenciesClient Dependencies { get { return (IWrikeDependenciesClient)this; } } 
        
        //TODO: implement dependencies methods 
        //https://developers.wrike.com/documentation/api/methods/query-dependencies
    }
}
