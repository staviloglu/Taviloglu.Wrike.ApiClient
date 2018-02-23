using System;

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
