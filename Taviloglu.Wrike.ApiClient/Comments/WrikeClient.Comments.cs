using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeCommentsClient
    {
        public IWrikeCommentsClient Comments
        {
            get
            {
                //return (IWrikeCommentsClient)this;
                throw new NotImplementedException("Comments not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
