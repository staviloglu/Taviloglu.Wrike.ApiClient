using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.WebHooks.Sample.WebHooks
{
    public class WrikeWebHookHandler : WrikeWebHookHandlerBase
    {
        public override void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent data)
        {
            throw new NotImplementedException();
        }

        public override void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent data)
        {
            throw new NotImplementedException();
        }
    }
}
