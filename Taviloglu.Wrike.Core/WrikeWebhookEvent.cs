using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWebhookEvent
    {
        //TODO: implement other oldvalue included events properties, write json properties, change names
        public string oldStatus { get; set; }
        public string status { get; set; }
        public string taskId { get; set; }
        public string webhookId { get; set; }
        public string eventAuthorId { get; set; }
        public string eventType { get; set; }
        public DateTime lastUpdatedDate { get; set; }
    }

}
