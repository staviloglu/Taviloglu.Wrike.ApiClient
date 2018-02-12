using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

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
