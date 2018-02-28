using Microsoft.AspNetCore.Mvc;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.WebHook.Samples.Controllers
{
    [Route("api/[controller]")]
    public class WrikeWebHookController : WrikeWebHookControllerBase
    {
        protected override void OnAttachmentAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnAttachmentDeleted(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnCommentAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnCommentDeleted(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskDatesChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskImportanceChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskParentsAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskParentsRemoved(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskResponsiblesAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskResponsiblesRemoved(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskSharedsAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskSharedsRemoved(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }

        protected override void OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            //TODO: write some code
        }
    }
}
