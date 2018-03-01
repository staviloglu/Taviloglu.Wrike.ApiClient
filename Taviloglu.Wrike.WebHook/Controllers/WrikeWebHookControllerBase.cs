using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.WebHook.Extensions;

namespace Taviloglu.Wrike.WebHook
{
    public abstract class WrikeWebHookControllerBase : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] JArray array)
        {
            //TODO: add security check to ensure the post is coming fomr Wrike

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
                        var importanceChangedEvent = array.First.ToObject<WrikeWebHookTaskImportanceChangedEvent>();
                        OnTaskImportanceChanged(importanceChangedEvent);
                        break;
                    case WrikeWebHookEventType.TaskStatusChanged:
                        var statusChangedEvent = array.First.ToObject<WrikeWebHookTaskStatusChangedEvent>();
                        OnTaskStatusChanged(statusChangedEvent);
                        break;
                    case WrikeWebHookEventType.TaskDatesChanged:
                        var datesChangedEvent = array.First.ToObject<WrikeWebHookTaskDatesChangedEvent>();
                        OnTaskDatesChanged(datesChangedEvent);
                        break;
                    case WrikeWebHookEventType.TaskParentsAdded:
                        OnTaskParentsAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskParentsRemoved:
                        OnTaskParentsAdded(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesAdded:
                        var responsiblesAddedEvent = array.First.ToObject<WrikeWebHookTaskResponsiblesAddedEvent>();
                        OnTaskResponsiblesAdded(responsiblesAddedEvent);
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesRemoved:
                        OnTaskResponsiblesRemoved(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskSharedsAdded:
                        var sharedsAddedEvent = array.First.ToObject<WrikeWebHookTaskSahredsAddedEvent>();
                        OnTaskSharedsAdded(sharedsAddedEvent);
                        break;
                    case WrikeWebHookEventType.TaskSharedsRemoved:
                        OnTaskSharedsRemoved(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskDescriptionChanged:
                        OnTaskDescriptionChanged(webHookEvent);
                        break;
                    case WrikeWebHookEventType.AttachmentAdded:
                        var attachmentAddedEvent = array.First.ToObject<WrikeWebHookAttachmentEvent>();
                        OnAttachmentAdded(attachmentAddedEvent);
                        break;
                    case WrikeWebHookEventType.AttachmentDeleted:
                        var attachmentDeletedEvent = array.First.ToObject<WrikeWebHookAttachmentEvent>();
                        OnAttachmentDeleted(attachmentDeletedEvent);
                        break;
                    case WrikeWebHookEventType.CommentAdded:
                        var commentAddedEvent = array.First.ToObject<WrikeWebHookCommentEvent>();
                        OnCommentAdded(commentAddedEvent);
                        break;
                    case WrikeWebHookEventType.CommentDeleted:
                        var commentDeletedEvent = array.First.ToObject<WrikeWebHookCommentEvent>();
                        OnCommentDeleted(commentDeletedEvent);
                        break;
                    case WrikeWebHookEventType.TimelogChanged:
                        OnTimelogChanged(webHookEvent);
                        break;
                }
            }
            catch (Exception ex)
            {
                OnError(ex);
            }

            return Ok();
        }

        protected virtual void OnError(Exception ex) { }

        protected virtual void OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskImportanceChanged(WrikeWebHookTaskImportanceChangedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskDatesChanged(WrikeWebHookTaskDatesChangedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskParentsAdded(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskParentsRemoved(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskResponsiblesAdded(WrikeWebHookTaskResponsiblesAddedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskResponsiblesRemoved(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskSharedsAdded(WrikeWebHookTaskSahredsAddedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskSharedsRemoved(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnAttachmentAdded(WrikeWebHookAttachmentEvent wrikeWebHookEvent) { }
        protected virtual void OnAttachmentDeleted(WrikeWebHookAttachmentEvent wrikeWebHookEvent) { }
        protected virtual void OnCommentAdded(WrikeWebHookCommentEvent wrikeWebHookEvent) { }
        protected virtual void OnCommentDeleted(WrikeWebHookCommentEvent wrikeWebHookEvent) { }
        protected virtual void OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent) { }
    }
}
