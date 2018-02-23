using System;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeIdsClient
    {
        public IWrikeIdsClient Ids
        {
            get
            {
                //return (IWrikeIdsClient)this;
                throw new NotImplementedException("Ids not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
