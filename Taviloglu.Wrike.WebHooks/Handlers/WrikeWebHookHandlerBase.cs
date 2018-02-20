using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.WebHooks
{
    public abstract class WrikeWebHookHandlerBase : WebHookHandler
    {
        protected WrikeWebHookHandlerBase()
        {
            Receiver = WrikeWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var eventTypeAsString = context.Actions.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(eventTypeAsString))
            {
                WrikeWebHookEventType eventType = (WrikeWebHookEventType)Enum.Parse(typeof(WrikeWebHookEventType), eventTypeAsString);

                switch (eventType)
                {
                    case WrikeWebHookEventType.TaskCreated:
                        OnTaskCreated(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskDeleted:
                        OnTaskDeleted(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskTitleChanged:
                        OnTaskTitleChanged(context.GetDataOrDefault<WrikeWebHookTaskTitleChangedEvent>());
                        break;
                    case WrikeWebHookEventType.TaskImportanceChanged:
                        OnTaskImportanceChanged(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskStatusChanged:
                        OnTaskStatusChanged(context.GetDataOrDefault<WrikeWebHookTaskStatusChangedEvent>());
                        break;
                    case WrikeWebHookEventType.TaskDatesChanged:
                        OnTaskDatesChanged(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskParentsAdded:
                        OnTaskParentsAdded(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskParentsRemoved:
                        OnTaskParentsAdded(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesAdded:
                        OnTaskResponsiblesAdded(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesRemoved:
                        OnTaskResponsiblesRemoved(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskSharedsAdded:
                        OnTaskSharedsAdded(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskSharedsRemoved:
                        OnTaskSharedsRemoved(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TaskDescriptionChanged:
                        OnTaskDescriptionChanged(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.AttachmentAdded:
                        OnAttachmentAdded(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.AttachmentDeleted:
                        OnAttachmentDeleted(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.CommentAdded:
                        OnCommentAdded(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.CommentDeleted:
                        OnCommentDeleted(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    case WrikeWebHookEventType.TimelogChanged:
                        OnTimelogChanged(context.GetDataOrDefault<WrikeWebHookEvent>());
                        break;
                    default:
                        throw new Exception("Unknown WrikeWebHookEventType");
                }
            }
            else
            {
                throw new Exception("Unknown WrikeWebHookEventType");
            }

            return Task.FromResult(true);
        }

        public abstract void OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent data);
        public abstract void OnTaskImportanceChanged(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent data);
        public abstract void OnTaskDatesChanged(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskParentsAdded(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskParentsRemoved(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskResponsiblesAdded(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskResponsiblesRemoved(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskSharedsAdded(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskSharedsRemoved(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnAttachmentAdded(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnAttachmentDeleted(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnCommentAdded(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnCommentDeleted(WrikeWebHookEvent wrikeWebHookEvent);
        public abstract void OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent);
    }
}
