using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeAccountsClient
    {
        public IWrikeAccountsClient Accounts
        {
            get
            {
                //return (IWrikeAccountsClient)this;
                throw new NotImplementedException("accounts not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
