using System;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeTimelogsClient
    {
        public IWrikeTimelogsClient Timelogs
        {
            get
            {
                //return (IWrikeTimelogsClient)this;
                throw new NotImplementedException("Timelogs not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
