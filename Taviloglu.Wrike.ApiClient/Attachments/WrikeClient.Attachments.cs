using System;

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
