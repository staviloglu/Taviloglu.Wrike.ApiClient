using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

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
