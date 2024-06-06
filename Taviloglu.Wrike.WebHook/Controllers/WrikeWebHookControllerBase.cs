using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
        public IActionResult Post()
        {
            //TODO: add security check to ensure the post is coming from Wrike

            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var jsonContent = reader.ReadToEnd();

                if (IsWebHookSetup(jsonContent))
                {
                    return HandleWebHookSetup(jsonContent);
                }
                else
                {
                    var array = new JArray(jsonContent);
                    if (!Request.IsLocal() && !Request.IsHttps)
                    {
                        return new BadRequestResult();
                    }

                    if (array.Count < 1)
                    {
                        return new BadRequestResult();
                    }

                    string auth = AuthenticateRequest(jsonContent);
                    if (string.IsNullOrEmpty(auth))
                    {
                        return Unauthorized();
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
            }
        }

        protected virtual IActionResult HandleWebHookSetup(string jsonContent)
        {
            return BadRequest();
        }

        protected virtual string AuthenticateRequest(string jsonContent)
        {
            return null;
        }

        private bool IsWebHookSetup(string jsonContent)
        {
            return jsonContent.Contains("WebHook secret verification");
        }

        private IActionResult HandleEvent(JToken eventData)
        {
            var webHookEvent = eventData.ToObject<WrikeWebHookEvent>();

            if (string.IsNullOrWhiteSpace(webHookEvent.TaskId))
            {
                throw new ArgumentException("Invalid Event Data. TaskId is required");
            }

            var response = _handler.OnEvent(eventData, webHookEvent);
            if (response ) { return Ok();  }

            switch (webHookEvent.Type)
            {
                case WrikeWebHookEventType.TaskCreated:
                    _handler.OnTaskCreated(webHookEvent);
                    break;
                case WrikeWebHookEventType.TaskDeleted:
                    _handler.OnTaskDeleted(webHookEvent);
                    break;
                case WrikeWebHookEventType.TaskTitleChanged:
                    var titleChangedEvent = eventData.ToObject<WrikeWebHookTaskTitleChangedEvent>();
                    _handler.OnTaskTitleChanged(titleChangedEvent);
                    break;
                case WrikeWebHookEventType.TaskImportanceChanged:
                    var importanceChangedEvent = eventData.ToObject<WrikeWebHookTaskImportanceChangedEvent>();
                    _handler.OnTaskImportanceChanged(importanceChangedEvent);
                    break;
                case WrikeWebHookEventType.TaskStatusChanged:
                    var statusChangedEvent = eventData.ToObject<WrikeWebHookTaskStatusChangedEvent>();
                    _handler.OnTaskStatusChanged(statusChangedEvent);
                    break;
                case WrikeWebHookEventType.TaskDatesChanged:
                    var datesChangedEvent = eventData.ToObject<WrikeWebHookTaskDatesChangedEvent>();
                    _handler.OnTaskDatesChanged(datesChangedEvent);
                    break;
                case WrikeWebHookEventType.TaskParentsAdded:
                    var parentsAddedEvent = eventData.ToObject<WrikeWebHookTaskParentsAddedEvent>();
                    _handler.OnTaskParentsAdded(parentsAddedEvent);
                    break;
                case WrikeWebHookEventType.TaskParentsRemoved:
                    var parentsRemovedEvent = eventData.ToObject<WrikeWebHookTaskParentsRemovedEvent>();
                    _handler.OnTaskParentsRemoved(parentsRemovedEvent);
                    break;
                case WrikeWebHookEventType.TaskResponsiblesAdded:
                    var responsiblesAddedEvent = eventData.ToObject<WrikeWebHookTaskResponsiblesAddedEvent>();
                    _handler.OnTaskResponsiblesAdded(responsiblesAddedEvent);
                    break;
                case WrikeWebHookEventType.TaskResponsiblesRemoved:
                    var responsiblesRemovedEvent = eventData.ToObject<WrikeWebHookTaskResponsiblesRemovedEvent>();
                    _handler.OnTaskResponsiblesRemoved(responsiblesRemovedEvent);
                    break;
                case WrikeWebHookEventType.TaskSharedsAdded:
                    var sharedsAddedEvent = eventData.ToObject<WrikeWebHookTaskSharedsAddedEvent>();
                    _handler.OnTaskSharedsAdded(sharedsAddedEvent);
                    break;
                case WrikeWebHookEventType.TaskSharedsRemoved:
                    var sharedsRemovedEvent = eventData.ToObject<WrikeWebHookTaskSharedsRemovedEvent>();
                    _handler.OnTaskSharedsRemoved(sharedsRemovedEvent);
                    break;
                case WrikeWebHookEventType.TaskDescriptionChanged:
                    _handler.OnTaskDescriptionChanged(webHookEvent);
                    break;
                case WrikeWebHookEventType.AttachmentAdded:
                    var attachmentAddedEvent = eventData.ToObject<WrikeWebHookAttachmentEvent>();
                    _handler.OnAttachmentAdded(attachmentAddedEvent);
                    break;
                case WrikeWebHookEventType.AttachmentDeleted:
                    var attachmentDeletedEvent = eventData.ToObject<WrikeWebHookAttachmentEvent>();
                    _handler.OnAttachmentDeleted(attachmentDeletedEvent);
                    break;
                case WrikeWebHookEventType.CommentAdded:
                    var commentAddedEvent = eventData.ToObject<WrikeWebHookCommentEvent>();
                    _handler.OnCommentAdded(commentAddedEvent);
                    break;
                case WrikeWebHookEventType.CommentDeleted:
                    var commentDeletedEvent = eventData.ToObject<WrikeWebHookCommentEvent>();
                    _handler.OnCommentDeleted(commentDeletedEvent);
                    break;
                case WrikeWebHookEventType.TimelogChanged:
                    _handler.OnTimelogChanged(webHookEvent);
                    break;
            }

            return Ok();
        }

 

       
    }
}
