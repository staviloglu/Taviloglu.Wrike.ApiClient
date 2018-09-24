namespace Taviloglu.Wrike.Core.Webhooks
{
    public enum WrikeWebHookEventType
    {
        /// <summary>
        /// Fired when user creates a new task
        /// </summary>
        TaskCreated,
        /// <summary>
        /// Per-account hooks: Fired when a user deletes a task
        /// Per-Folder hooks: Not fired
        /// </summary>
        TaskDeleted,
        /// <summary>
        /// Fired when task title changed, Includes old value
        /// </summary>
        TaskTitleChanged,
        /// <summary>
        /// Fired when task importance changed, Includes old value
        /// </summary>
        TaskImportanceChanged,
        /// <summary>
        /// Fired when task status changed, Includes old value
        /// </summary>
        TaskStatusChanged,
        /// <summary>
        /// Fired when start, finish dates, duration, or the “Work on weekends” flag is changed, Includes old value
        /// </summary>
        TaskDatesChanged,
        /// <summary>
        /// Fired when a task is added to a Folder
        /// </summary>
        TaskParentsAdded,
        /// <summary>
        /// Fired when a task is removed from a Folder
        /// </summary>
        TaskParentsRemoved,
        /// <summary>
        /// Fired when a new assignee is added to a task, including all Wrike users (and Collaborators) and users with pending invitations.
        /// </summary>
        TaskResponsiblesAdded,
        /// <summary>
        /// Fired when someone is unassigned from a task
        /// </summary>
        TaskResponsiblesRemoved,
        /// <summary>
        /// Fired when a task is shared
        /// </summary>
        TaskSharedsAdded,
        /// <summary>
        /// Fired when a task is unshared
        /// </summary>
        TaskSharedsRemoved,
        /// <summary>
        /// Fired when a task’s description is changed. Note: Notifications related to description field changes are fired with a 5 min delay (approximately)
        /// </summary>
        TaskDescriptionChanged,
        /// <summary>
        /// Fired when a new attachment is added to a task
        /// </summary>
        AttachmentAdded,
        /// <summary>
        /// Fired when attachment was deleted from task or comment with attachment was deleted
        /// </summary>
        AttachmentDeleted,
        /// <summary>
        /// Fired when a new comment is added. Not fired for comments without text, i.e. comments with attachments only
        /// </summary>
        CommentAdded,
        /// <summary>
        /// Fired when a comment is deleted
        /// </summary>
        CommentDeleted,
        /// <summary>
        /// Fired when a Timelog record is added, updated, or removed
        /// </summary>
        TimelogChanged
    }
}
