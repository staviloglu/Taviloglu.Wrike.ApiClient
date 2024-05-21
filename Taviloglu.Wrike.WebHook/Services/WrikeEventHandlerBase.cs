using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Taviloglu.Wrike.Core.WebHooks;

namespace Taviloglu.Wrike.WebHook.Services
{
    public abstract class WrikeEventHandlerBase
    {
        public virtual OkResult Ok()
        {
            return new OkResult();
        }
        public virtual OkObjectResult Ok(object value)
        {
            return new OkObjectResult(value);
        }

        public virtual BadRequestResult BadRequest()
        {
            return new BadRequestResult();
        }
        public virtual BadRequestObjectResult BadRequest(object error)
        {
            return new BadRequestObjectResult(error);
        }

        public virtual IActionResult OnEvent(JToken eventData, WrikeWebHookEvent wrikeWebHookEvent) { return null; }

        public virtual IActionResult OnError(Exception ex) { return BadRequest(); }
        public virtual IActionResult OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskImportanceChanged(WrikeWebHookTaskImportanceChangedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskDatesChanged(WrikeWebHookTaskDatesChangedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskParentsAdded(WrikeWebHookTaskParentsAddedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskParentsRemoved(WrikeWebHookTaskParentsRemovedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskResponsiblesAdded(WrikeWebHookTaskResponsiblesAddedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskResponsiblesRemoved(WrikeWebHookTaskResponsiblesRemovedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskSharedsAdded(WrikeWebHookTaskSharedsAddedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskSharedsRemoved(WrikeWebHookTaskSharedsRemovedEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnAttachmentAdded(WrikeWebHookAttachmentEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnAttachmentDeleted(WrikeWebHookAttachmentEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnCommentAdded(WrikeWebHookCommentEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnCommentDeleted(WrikeWebHookCommentEvent wrikeWebHookEvent) { return Ok(); }
        public virtual IActionResult OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent) { return Ok(); }
    }
}
