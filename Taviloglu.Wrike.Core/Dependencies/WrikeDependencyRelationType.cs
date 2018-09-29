namespace Taviloglu.Wrike.Core.Dependencies
{
    /// <summary>
    /// Relation between Predecessor and Successor 
    /// </summary>
    public enum WrikeDependencyRelationType
    {
        /// <summary>
        /// Task B can't start before Task A starts.
        /// </summary>
        StartToStart,
        /// <summary>
        /// Task B can't finish before Task A starts.
        /// </summary>
        StartToFinish,
        /// <summary>
        /// Task B can't start before Task A is finished.
        /// </summary>
        FinishToStart,
        /// <summary>
        /// Task B can't finish before Task A is finished.
        /// </summary>
        FinishToFinish
    }
}
