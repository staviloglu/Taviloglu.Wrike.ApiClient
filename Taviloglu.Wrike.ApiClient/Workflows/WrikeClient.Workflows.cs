using System;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeWorkflowsClient
    {
        public IWrikeWorkflowsClient Workflows
        {
            get
            {
                //return (IWrikeWorkflowsClient)this;
                throw new NotImplementedException("Workflows not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
