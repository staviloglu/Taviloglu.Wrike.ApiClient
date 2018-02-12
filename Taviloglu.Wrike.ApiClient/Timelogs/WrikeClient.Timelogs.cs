using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeTimelogsClient
    {
        public IWrikeTimelogsClient Timelogs
        {
            get
            {
                return (IWrikeTimelogsClient)this;
            }
        }

        //todo: implement methods
    }
}
