using System;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeDependenciesClient
    {
        public IWrikeDependenciesClient Dependencies
        {
            get
            {
                //return (IWrikeDependenciesClient)this;
                throw new NotImplementedException("Dependencies not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
