using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using Taviloglu.Wrike.Core.WebHooks;
using Taviloglu.Wrike.WebHook.Extensions;
using Taviloglu.Wrike.WebHook.Services;

namespace Taviloglu.Wrike.WebHook
{
    public abstract class WrikeWebHookControllerBase : ControllerBase
    {
        private WrikeEventHandlerBase _handler;
        public WrikeWebHookControllerBase(WrikeEventHandlerBase handler) => _handler = handler;

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
                return HandleEvent(array.First);
            }
            catch (Exception ex)
            {
                _handler.OnError(ex);
                return new BadRequestResult();
            }
        }

        private IActionResult HandleEvent(JToken eventData)
        {
            var webHookEvent = eventData.ToObject<WrikeWebHookEvent>();

            if (string.IsNullOrWhiteSpace(webHookEvent.TaskId))
            {
                throw new ArgumentException("Invalid Event Data. TaskId is required");
            }

            var response = _handler.OnEvent(eventData, webHookEvent);
            if (response != null) { return response;  }

            switch (webHookEvent.Type)
            {
                case WrikeWebHookEventType.TaskCreated:
                    return _handler.OnTaskCreated(webHookEvent);
                case WrikeWebHookEventType.TaskDeleted:
                    return _handler.OnTaskDeleted(webHookEvent);
                case WrikeWebHookEventType.TaskTitleChanged:
                    var titleChangedEvent = eventData.ToObject<WrikeWebHookTaskTitleChangedEvent>();
                    return _handler.OnTaskTitleChanged(titleChangedEvent);
                case WrikeWebHookEventType.TaskImportanceChanged:
                    var importanceChangedEvent = eventData.ToObject<WrikeWebHookTaskImportanceChangedEvent>();
                    return _handler.OnTaskImportanceChanged(importanceChangedEvent);
                case WrikeWebHookEventType.TaskStatusChanged:
                    var statusChangedEvent = eventData.ToObject<WrikeWebHookTaskStatusChangedEvent>();
                    return _handler.OnTaskStatusChanged(statusChangedEvent);
                case WrikeWebHookEventType.TaskDatesChanged:
                    var datesChangedEvent = eventData.ToObject<WrikeWebHookTaskDatesChangedEvent>();
                    return _handler.OnTaskDatesChanged(datesChangedEvent);
                case WrikeWebHookEventType.TaskParentsAdded:
                    var parentsAddedEvent = eventData.ToObject<WrikeWebHookTaskParentsAddedEvent>();
                    return _handler.OnTaskParentsAdded(parentsAddedEvent);
                case WrikeWebHookEventType.TaskParentsRemoved:
                    var parentsRemovedEvent = eventData.ToObject<WrikeWebHookTaskParentsRemovedEvent>();
                    return _handler.OnTaskParentsRemoved(parentsRemovedEvent);
                case WrikeWebHookEventType.TaskResponsiblesAdded:
                    var responsiblesAddedEvent = eventData.ToObject<WrikeWebHookTaskResponsiblesAddedEvent>();
                    return _handler.OnTaskResponsiblesAdded(responsiblesAddedEvent);
                case WrikeWebHookEventType.TaskResponsiblesRemoved:
                    var responsiblesRemovedEvent = eventData.ToObject<WrikeWebHookTaskResponsiblesRemovedEvent>();
                    return _handler.OnTaskResponsiblesRemoved(responsiblesRemovedEvent);
                case WrikeWebHookEventType.TaskSharedsAdded:
                    var sharedsAddedEvent = eventData.ToObject<WrikeWebHookTaskSharedsAddedEvent>();
                    return _handler.OnTaskSharedsAdded(sharedsAddedEvent);
                case WrikeWebHookEventType.TaskSharedsRemoved:
                    var sharedsRemovedEvent = eventData.ToObject<WrikeWebHookTaskSharedsRemovedEvent>();
                    return _handler.OnTaskSharedsRemoved(sharedsRemovedEvent);
                case WrikeWebHookEventType.TaskDescriptionChanged:
                    return _handler.OnTaskDescriptionChanged(webHookEvent);
                case WrikeWebHookEventType.AttachmentAdded:
                    var attachmentAddedEvent = eventData.ToObject<WrikeWebHookAttachmentEvent>();
                    return _handler.OnAttachmentAdded(attachmentAddedEvent);
                case WrikeWebHookEventType.AttachmentDeleted:
                    var attachmentDeletedEvent = eventData.ToObject<WrikeWebHookAttachmentEvent>();
                    return _handler.OnAttachmentDeleted(attachmentDeletedEvent);
                case WrikeWebHookEventType.CommentAdded:
                    var commentAddedEvent = eventData.ToObject<WrikeWebHookCommentEvent>();
                    return _handler.OnCommentAdded(commentAddedEvent);
                case WrikeWebHookEventType.CommentDeleted:
                    var commentDeletedEvent = eventData.ToObject<WrikeWebHookCommentEvent>();
                    return _handler.OnCommentDeleted(commentDeletedEvent);
                case WrikeWebHookEventType.TimelogChanged:
                    return _handler.OnTimelogChanged(webHookEvent);
            }

            return new OkResult();
        }

       
    }
}
