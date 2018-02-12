using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeIdsClient
    {
        public IWrikeIdsClient Ids
        {
            get
            {
                //return (IWrikeIdsClient)this;
                throw new NotImplementedException("Ids not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
