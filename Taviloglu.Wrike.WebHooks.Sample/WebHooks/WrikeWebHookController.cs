using System;
using System.Web.Http;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.WebHooks.Sample.WebHooks
{
    public class WrikeWebHookController : WrikeWebHookControllerBase
    {
        protected override void OnAttachmentAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnAttachmentDeleted(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnCommentAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnCommentDeleted(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskDatesChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskImportanceChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskParentsAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskParentsRemoved(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskResponsiblesAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskResponsiblesRemoved(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskSharedsAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskSharedsRemoved(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }
    }
}
