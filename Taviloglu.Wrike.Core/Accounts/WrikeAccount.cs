using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.CustomFields;
using Taviloglu.Wrike.Core.Json;
using Taviloglu.Wrike.Core.Subscriptions;

namespace Taviloglu.Wrike.Core.Accounts
{

    public class WrikeAccount : WrikeObjectWithId
    {

        /// <summary>
        /// Name of account 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Date format: dd/MM/yyyy or MM/dd/yyyy
        /// </summary>
        [JsonProperty("dateFormat")]
        public string DateFormat { get; set; }

        /// <summary>
        /// First day of week Week Day, Enum: Sat, Sun, Mon
        /// </summary>
        [JsonProperty("firstDayOfWeek")]
        public string FirstDayOfWeek { get; set; }

        /// <summary>
        /// List of weekdays, not empty. These days are used in task duration computation Week Day, Enum: Sun, Mon, Tue, Wed, Thu, Fri, Sat
        /// </summary>
        [JsonProperty("workDays")]
        public List<string> WorkDays { get; set; }

        /// <summary>
        /// Virtual folder, denotes the root folder of the account. Different users can have different elements in the root, according to their sharing scope. 
        /// Can be used in queries to get all folders/tasks in the account, or to create folders/tasks in the user's account root
        /// </summary>
        [JsonProperty("rootFolderId")]
        public string RootFolderId { get; set; }

        /// <summary>
        /// Virtual folder, denotes the root for deleted folders and tasks. Can be used in queries to get all folders/tasks in the Recycle Bin. Cannot be used in modification queries. 
        /// </summary>
        [JsonProperty("recycleBinId")]
        public string RecycleBinId { get; set; }

        /// <summary>
        /// Registration date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("createdDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Account subscription
        /// </summary>
        [JsonProperty("subscription")]
        public WrikeSubscription Subscription { get; set; }

        /// <summary>
        /// List of account metadata entries. Entries could be read by all users of account and modified by admins only
        /// </summary>
        [JsonProperty("metadata")]
        public List<WrikeMetadata> Metadata { get; set; }

        /// <summary>
        /// List of custom fields accessible for requesting user in the account
        /// </summary>
        [JsonProperty("customFields")]
        public List<WrikeCustomField> CustomFields { get; set; }

        /// <summary>
        /// Date when the user has joined the account Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("joinedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime JoinedDate { get; set; }

        /// <summary>
        /// Optional fields to be included in the response model 
        /// </summary>
        public static class OptionalFields
        {
            public static List<string> List = new List<string>{ Subscription, Metadata, CustomFields };

            /// <summary>
            /// Account subscription
            /// </summary>
            public const string Subscription = "subscription";

            /// <summary>
            /// Account metadata
            /// </summary>
            public const string Metadata = "metadata";

            /// <summary>
            /// Account custom fields
            /// </summary>
            public const string CustomFields = "customFields";
        }
    }
   



}
