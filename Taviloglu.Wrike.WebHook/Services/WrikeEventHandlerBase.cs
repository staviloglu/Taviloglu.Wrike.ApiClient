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
        public virtual bool OnEvent(JToken eventData, WrikeWebHookEvent wrikeWebHookEvent) { return false; }

        public virtual void OnError(Exception ex) { }
        public virtual void OnTaskCreated(WrikeWebHookEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskDeleted(WrikeWebHookEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskTitleChanged(WrikeWebHookTaskTitleChangedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskImportanceChanged(WrikeWebHookTaskImportanceChangedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskStatusChanged(WrikeWebHookTaskStatusChangedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskDatesChanged(WrikeWebHookTaskDatesChangedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskParentsAdded(WrikeWebHookTaskParentsAddedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskParentsRemoved(WrikeWebHookTaskParentsRemovedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskResponsiblesAdded(WrikeWebHookTaskResponsiblesAddedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskResponsiblesRemoved(WrikeWebHookTaskResponsiblesRemovedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskSharedsAdded(WrikeWebHookTaskSharedsAddedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskSharedsRemoved(WrikeWebHookTaskSharedsRemovedEvent wrikeWebHookEvent) {  }
        public virtual void OnTaskDescriptionChanged(WrikeWebHookEvent wrikeWebHookEvent) {  }
        public virtual void OnAttachmentAdded(WrikeWebHookAttachmentEvent wrikeWebHookEvent) {  }
        public virtual void OnAttachmentDeleted(WrikeWebHookAttachmentEvent wrikeWebHookEvent) {  }
        public virtual void OnCommentAdded(WrikeWebHookCommentEvent wrikeWebHookEvent) {  }
        public virtual void OnCommentDeleted(WrikeWebHookCommentEvent wrikeWebHookEvent) {  }
        public virtual void OnTimelogChanged(WrikeWebHookEvent wrikeWebHookEvent) {  }
    }
}
