using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeContactsClient
    {
        public IWrikeContactsClient Contacts
        {
            get
            {
                return (IWrikeContactsClient)this;
            }
        }

        //todo: implement methods
    }
}
