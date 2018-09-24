namespace Taviloglu.Wrike.Core.Tasks
{
    public enum WrikeTaskSortField
    {
        /// <summary>
        /// Sort by created date
        /// </summary>
        CreatedDate,
        /// <summary>
        /// Sort by updated date
        /// </summary>
        UpdatedDate,
        /// <summary>
        /// Sort by completed date
        /// </summary>
        CompletedDate,
        /// <summary>
        /// Sort by due date
        /// </summary>
        DueDate,
        /// <summary>
        /// Sort by status
        /// </summary>
        Status,
        /// <summary>
        /// Sort by importance
        /// </summary>
        Importance,
        /// <summary>
        /// Lexicographic sorting by title
        /// </summary>
        Title
    }
}
