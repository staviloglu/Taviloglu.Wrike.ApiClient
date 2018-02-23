using System;

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
