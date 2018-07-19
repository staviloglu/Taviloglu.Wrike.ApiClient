namespace Taviloglu.Wrike.ApiClient.FoldersAndProjects
{
    /// <summary>
    /// Mode to be used for rescheduling (based on first or last date), has effect only if reschedule date is specified. 
    /// </summary>
    public enum FolderRescheduleMode
    {
        /// <summary>
        /// Tasks in scope are rescheduled starting from reschedule date
        /// </summary>
        Start,
        /// <summary>
        /// Tasks in scope are rescheduled ending with reschedule date
        /// </summary>
        End
    }
}
