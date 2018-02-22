using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.WebHook.Extensions;

namespace Taviloglu.Wrike.WebHook
{
    public abstract class WrikeWebHookControllerBase : ControllerBase
    {
        [HttpPost]
        public  async Task<IActionResult> Post([FromBody] JArray array)
        {

            if (!Request.IsLocal() && !Request.IsHttps)
            {
                return new BadRequestResult();
            }

            if (array.Count < 1)
            {
                return new BadRequestResult();
            }

            try
            {
                var webHookEvent = array.First.ToObject<WrikeWebHookEvent>();

                switch (webHookEvent.Type)
                {
                    case WrikeWebHookEventType.TaskCreated:
                        OnTaskCreated(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskDeleted:
                        OnTaskDeleted(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskTitleChanged:
                        var titleChangedEvent = array.First.ToObject<WrikeWebHookTaskTitleChangedEvent>();
                        OnTaskTitleChanged(titleChangedEvent);
                        break;
                    case WrikeWebHookEventType.TaskImportanceChanged:
                        OnTaskImportanceChanged(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskStatusChanged:
                        var statusChangedEvent = array.First.ToObject<WrikeWebHookTaskStatusChangedEvent>();
                        OnTaskStatusChanged(statusChangedEvent);
                        break;
                    case WrikeWebHookEventType.TaskDatesChanged:
                        OnTaskDatesChanged(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskParentsAdded:
                        OnTaskParentsAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskParentsRemoved:
                        OnTaskParentsAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesAdded:
                        OnTaskResponsiblesAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesRemoved:
                        OnTaskResponsiblesRemoved(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskSharedsAdded:
                        OnTaskSharedsAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskSharedsRemoved:
                        OnTaskSharedsRemoved(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskDescriptionChanged:
                        OnTaskDescriptionChanged(webHookEvent);
                        break;
                    case WrikeWebHookEventType.AttachmentAdded:
                        OnAttachmentAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.AttachmentDeleted:
                        OnAttachmentDeleted(webHookEvent);
                        break;
                    case WrikeWebHookEventType.CommentAdded:
                        OnCommentAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.CommentDeleted:
                        OnCommentDeleted(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TimelogChanged:
                        OnTimelogChanged(webHookEvent);
                        break;
                    default:
                        return new BadRequestResult();
                }
            }
            catch
            {
                return new BadRequestResult();
            }

            return Ok();
        }

        protected abstract void OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent wrikeWebHookEvent);
        protected abstract void OnTaskImportanceChanged(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent wrikeWebHookEvent);
        protected abstract void OnTaskDatesChanged(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskParentsAdded(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskParentsRemoved(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskResponsiblesAdded(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskResponsiblesRemoved(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskSharedsAdded(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskSharedsRemoved(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnAttachmentAdded(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnAttachmentDeleted(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnCommentAdded(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnCommentDeleted(WrikeWebHookEvent wrikeWebHookEvent);
        protected abstract void OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent);
    }
}
