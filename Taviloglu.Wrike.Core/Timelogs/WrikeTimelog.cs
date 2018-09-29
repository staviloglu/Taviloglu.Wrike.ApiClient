using Newtonsoft.Json;
using System;
using Taviloglu.Wrike.Core.Extensions;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.Timelogs
{
    public class WrikeTimelog : WrikeObjectWithId
    {
        /// <summary>
        /// Use this constructor for creating new Timelog requests
        /// </summary>
        /// <param name="taskId">Create timelog record for task.</param>
        /// <param name="comment">Timelog record comment</param>
        /// <param name="hours">Time to log in hours, must be in [0..24] hours range</param>
        /// <param name="trackedDate">Date to register time </param>
        /// <param name="categoryId">Timelog category</param>
        public WrikeTimelog(string taskId, string comment, decimal hours, DateTime trackedDate, string categoryId = null)
        {
            taskId.ValidateParameter(nameof(taskId));

            comment.ValidateParameter(nameof(comment));

            if (hours < 0 || hours > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hours), "value must be in [0,24] range");
            }

            //TODO: check trackedDate

            TaskId = taskId;
            Comment = comment;
            Hours = hours;
            TrackedDate = trackedDate;
            CategoryId = categoryId;
        }
        /// <summary>
        /// Task to which timelog record is tracked
        /// </summary>
        [JsonProperty("taskId")]
        public string TaskId { get; private set; }

        /// <summary>
        /// User who tracked the timelog record
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Category of the timelog record
        /// </summary>
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Hours tracked in timelog record, must be in [0..24] hours range
        /// </summary>
        [JsonProperty("hours")]
        public decimal Hours { get; private set; }

        /// <summary>
        /// Date of timelog was created in user's timezone Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("createdDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date for which timelog was recorded Format: yyyy-MM-dd
        /// </summary>
        [JsonProperty("trackedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime TrackedDate { get; private set; }

        /// <summary>
        /// Timelog record comment
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; private set; }
    }
}
