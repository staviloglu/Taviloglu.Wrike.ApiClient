using Microsoft.AspNet.WebHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.WebHooks
{
    public abstract class WrikeWebHookHandler : WebHookHandler
    {
        public WrikeWebHookHandler()
        {
            Receiver = WrikeWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            var webHookEvent = context.GetDataOrDefault<WrikeWebHookEvent>();

            switch (webHookEvent.Type)
            {
                case WrikeWebHookEventType.TaskCreated:
                    break;
                case WrikeWebHookEventType.TaskDeleted:
                    break;
                case WrikeWebHookEventType.TaskTitleChanged:
                    OnTaskTitleChanged(context.GetDataOrDefault<WrikeWebHookTaskTitleChangedEvent>());
                    break;
                case WrikeWebHookEventType.TaskImportanceChanged:
                    break;
                case WrikeWebHookEventType.TaskStatusChanged:
                    OnTaskStatusChanged(context.GetDataOrDefault<WrikeWebHookTaskStatusChangedEvent>());
                    break;
                case WrikeWebHookEventType.TaskDatesChanged:
                    break;
                case WrikeWebHookEventType.TaskParentsAdded:
                    break;
                case WrikeWebHookEventType.TaskParentsRemoved:
                    break;
                case WrikeWebHookEventType.TaskResponsiblesAdded:
                    break;
                case WrikeWebHookEventType.TaskResponsiblesRemoved:
                    break;
                case WrikeWebHookEventType.TaskSharedsAdded:
                    break;
                case WrikeWebHookEventType.TaskSharedsRemoved:
                    break;
                case WrikeWebHookEventType.TaskDescriptionChanged:
                    break;
                case WrikeWebHookEventType.AttachmentAdded:
                    break;
                case WrikeWebHookEventType.AttachmentDeleted:
                    break;
                case WrikeWebHookEventType.CommentAdded:
                    break;
                case WrikeWebHookEventType.CommentDeleted:
                    break;
                case WrikeWebHookEventType.TimelogChanged:
                    break;
                default:
                    break;
            }

            return Task.FromResult(true);
        }

        public abstract void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent data);

        public abstract void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent data);
    }
}
