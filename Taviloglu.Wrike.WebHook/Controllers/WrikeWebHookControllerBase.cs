using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.WebHook.Extensions;

namespace Taviloglu.Wrike.WebHook
{
    public abstract class WrikeWebHookControllerBase : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post()
        {
            CheckContextAndContent();

            EnsureSecureConnection();

            List<WrikeWebHookEvent> webHookEvents = null;
            try
            {
                webHookEvents = Request.Content.ReadAsAsync<List<WrikeWebHookEvent>>().Result;
            }
            catch (Exception ex)
            {
                var message = string.Format("The WebHook request contained invalid JSON: '{0}'.", ex.Message);
                var invalidBody = Request.CreateErrorResponse(HttpStatusCode.BadRequest, message, ex);
                throw new HttpResponseException(invalidBody);
            }

            if (webHookEvents.Count < 1)
            {
                var invalidBody = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "could not find value");
                throw new HttpResponseException(invalidBody);
            }

            try
            {
                var webHookEvent = webHookEvents[0];

                switch (webHookEvent.Type)
                {
                    case WrikeWebHookEventType.TaskCreated:
                        OnTaskCreated(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskDeleted:
                        OnTaskDeleted(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskTitleChanged:
                        var titleChangedEvents = Request.Content.ReadAsAsync<List<WrikeWebHookTaskTitleChangedEvent>>().Result;
                        OnTaskTitleChanged(titleChangedEvents[0]);
                        break;
                    case WrikeWebHookEventType.TaskImportanceChanged:
                        OnTaskImportanceChanged(webHookEvent);
                        break;
                    case WrikeWebHookEventType.TaskStatusChanged:
                        var statusChangedEvents = Request.Content.ReadAsAsync<List<WrikeWebHookTaskStatusChangedEvent>>().Result;
                        OnTaskStatusChanged(statusChangedEvents[0]);
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
                        var message = string.Format("Unknown event type: {0}", webHookEvent.Type);
                        var invalidBody = Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
                        throw new HttpResponseException(invalidBody);
                }
            }
            catch (Exception ex)
            {
                var message = string.Format("The WebHook request contained invalid JSON: '{0}'.", ex.Message);
                var invalidBody = Request.CreateErrorResponse(HttpStatusCode.BadRequest, message, ex);
                throw new HttpResponseException(invalidBody);
            }

            return Ok();
        }

        private void EnsureSecureConnection()
        {
            // Require HTTP unless request is local
            if (!Request.IsLocal() && !Request.RequestUri.IsHttps())
            {
                var message = string.Format("The WebHook receiver '{0}' requires HTTPS in order to be secure. Please register a WebHook URI of type '{1}'.", GetType().Name, Uri.UriSchemeHttps);
                var noHttps = Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
                throw new HttpResponseException(noHttps);
            }
        }

        private void CheckContextAndContent()
        {
            if (RequestContext == null)
            {
                throw new ArgumentNullException(nameof(RequestContext));
            }
            if (Request == null)
            {
                throw new ArgumentNullException(nameof(Request));
            }

            // Check that there is a request body
            if (Request.Content == null)
            {
                var noBody = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The WebHook request entity body cannot be empty.");
                throw new HttpResponseException(noBody);
            }

            // Check that the request body is JSON
            if (!Request.Content.IsJson())
            {
                var noJson = Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "The WebHook request must contain an entity body formatted as JSON.");
                throw new HttpResponseException(noJson);
            }
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
