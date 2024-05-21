using Microsoft.AspNetCore.Mvc;
using System;
using Taviloglu.Wrike.Core.WebHooks;
using Taviloglu.Wrike.WebHook.Services;

namespace Taviloglu.Wrike.WebHook.Samples.Controllers
{
    [Route("api/[controller]")]
    public class WrikeWebHookController : WrikeWebHookControllerBase
    {
        public WrikeWebHookController() : base(new CustomHandler())
        {
        }
    }

    public class CustomHandler: WrikeEventHandlerBase { 
        public override IActionResult OnError(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return BadRequest();
        }

        public override IActionResult OnAttachmentAdded(WrikeWebHookAttachmentEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnAttachmentDeleted(WrikeWebHookAttachmentEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnCommentAdded(WrikeWebHookCommentEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();

        }

        public override IActionResult OnCommentDeleted(WrikeWebHookCommentEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskDatesChanged(WrikeWebHookTaskDatesChangedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskImportanceChanged(WrikeWebHookTaskImportanceChangedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskParentsAdded(WrikeWebHookTaskParentsAddedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskParentsRemoved(WrikeWebHookTaskParentsRemovedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskResponsiblesAdded(WrikeWebHookTaskResponsiblesAddedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskResponsiblesRemoved(WrikeWebHookTaskResponsiblesRemovedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskSharedsAdded(WrikeWebHookTaskSharedsAddedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskSharedsRemoved(WrikeWebHookTaskSharedsRemovedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }

        public override IActionResult OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
            return Ok();
        }
    }
}
