using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeAttachmentsClient
    {
        public IWrikeAttachmentsClient Attachments
        {
            get
            {
                //return (IWrikeAttachmentsClient)this;
                throw new NotImplementedException("Attachments not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
