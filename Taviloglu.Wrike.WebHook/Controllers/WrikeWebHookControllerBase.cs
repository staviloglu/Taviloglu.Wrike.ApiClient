using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using Taviloglu.Wrike.Core.Webhooks;
using Taviloglu.Wrike.WebHook.Extensions;

namespace Taviloglu.Wrike.WebHook
{
    public abstract class WrikeWebHookControllerBase : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] JArray array)
        {
            //TODO: add security check to ensure the post is coming from Wrike

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

                if (string.IsNullOrWhiteSpace(webHookEvent.TaskId))
                {
                    return new BadRequestResult();
                }

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
                        var parentsAddedEvent = array.First.ToObject<WrikeWebHookTaskParentsAddedEvent>();
                        OnTaskParentsAdded(parentsAddedEvent);
                        break;
                    case WrikeWebHookEventType.TaskParentsRemoved:
                        var parentsRemovedEvent = array.First.ToObject<WrikeWebHookTaskParentsRemovedEvent>();
                        OnTaskParentsRemoved(parentsRemovedEvent);
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesAdded:
                        var responsiblesAddedEvent = array.First.ToObject<WrikeWebHookTaskResponsiblesAddedEvent>();
                        OnTaskResponsiblesAdded(responsiblesAddedEvent);
                        break;
                    case WrikeWebHookEventType.TaskResponsiblesRemoved:
                        var responsiblesRemovedEvent = array.First.ToObject<WrikeWebHookTaskResponsiblesRemovedEvent>();
                        OnTaskResponsiblesRemoved(responsiblesRemovedEvent);
                        break;
                    case WrikeWebHookEventType.TaskSharedsAdded:
                        var sharedsAddedEvent = array.First.ToObject<WrikeWebHookTaskSharedsAddedEvent>();
                        OnTaskSharedsAdded(sharedsAddedEvent);
                        break;
                    case WrikeWebHookEventType.TaskSharedsRemoved:
                        var sharedsRemovedEvent = array.First.ToObject<WrikeWebHookTaskSharedsRemovedEvent>();
                        OnTaskSharedsRemoved(sharedsRemovedEvent);
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
        protected virtual void OnTaskParentsAdded(WrikeWebHookTaskParentsAddedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskParentsRemoved(WrikeWebHookTaskParentsRemovedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskResponsiblesAdded(WrikeWebHookTaskResponsiblesAddedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskResponsiblesRemoved(WrikeWebHookTaskResponsiblesRemovedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskSharedsAdded(WrikeWebHookTaskSharedsAddedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskSharedsRemoved(WrikeWebHookTaskSharedsRemovedEvent wrikeWebHookEvent) { }
        protected virtual void OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent) { }
        protected virtual void OnAttachmentAdded(WrikeWebHookAttachmentEvent wrikeWebHookEvent) { }
        protected virtual void OnAttachmentDeleted(WrikeWebHookAttachmentEvent wrikeWebHookEvent) { }
        protected virtual void OnCommentAdded(WrikeWebHookCommentEvent wrikeWebHookEvent) { }
        protected virtual void OnCommentDeleted(WrikeWebHookCommentEvent wrikeWebHookEvent) { }
        protected virtual void OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent) { }
    }
}
