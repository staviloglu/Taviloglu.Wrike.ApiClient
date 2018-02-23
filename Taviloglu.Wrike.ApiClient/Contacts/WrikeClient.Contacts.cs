using System;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeContactsClient
    {
        public IWrikeContactsClient Contacts
        {
            get
            {
                //return (IWrikeContactsClient)this;
                throw new NotImplementedException("Contacts not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
