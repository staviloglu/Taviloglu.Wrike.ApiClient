using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomFieldSettings : IWrikeObject
    {
        /// <summary>
        /// Custom field inheritance type
        /// </summary>
        [JsonProperty("inheritanceType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeCustomFieldInheritanceType InheritanceType { get; set; }
        /// <summary>
        /// Decimal places (only for Numeric, Percentage and Currency types)
        /// </summary>
        [JsonProperty("decimalPlaces")]
        public int? DecimalPlaces { get; set; }
        /// <summary>
        /// Use thousands separator (only for Numeric type)
        /// </summary>
        [JsonProperty("useThousandsSeparator")]
        public bool? UseThousandsSeparator { get; set; }


        /// <summary>
        /// Currency (only for Currency type) 
        /// </summary>
        [JsonProperty("currency")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeCustomFieldCurrency? Currency { get; set; }


        /// <summary>
        /// Aggregation type (only for Text, Numeric, Percentage, Currency, Duration and DropDown types)
        /// </summary>
        [JsonProperty("aggregation")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeCustomFieldAggregationType? Aggregation { get; set; }


        /// <summary>
        /// Dropdown values (only for DropDown type)
        /// </summary>
        [JsonProperty("values")]
        public List<string> Values { get; set; }


        /// <summary>
        /// Allow users to input other values (only for DropDown type)
        /// </summary>
        [JsonProperty("allowOtherValues")]
        public bool? AllowOtherValues { get; set; }

        /// <summary>
        /// Allowed users or invitations (only for Users type)
        /// </summary>
        [JsonProperty("contacts")]
        public List<string> Contacts { get; set; }


    }
}
