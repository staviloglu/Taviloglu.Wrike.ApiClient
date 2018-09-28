using Newtonsoft.Json;
using System;

namespace Taviloglu.Wrike.Core.CustomFields
{
    public sealed class WrikeCustomFieldData : IWrikeObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeCustomFieldData"/> class.
        /// </summary>
        /// <param name="customFieldId">Custom Field ID</param>
        /// <param name="value">Custom Field Value</param>
        public WrikeCustomFieldData(string customFieldId, string value) {

            if (customFieldId == null)
            {
                throw new ArgumentNullException(nameof(customFieldId));
            }

            if (customFieldId == string.Empty)
            {
                throw new ArgumentException("value can not be empty",nameof(customFieldId));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(value));
            }

            CustomFieldId = customFieldId;
            Value = value;
        }

        /// <summary>
        /// Custom field id
        /// </summary>
        [JsonProperty("id")]
        public string CustomFieldId { get; private set; }

        /// <summary>
        /// Custom field value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; private set; }

    }
}
