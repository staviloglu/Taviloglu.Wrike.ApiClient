using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.TimelogCategories
{
    public class WrikeTimelogCategory : WrikeObjectWithId
    {
        /// <summary>
        /// Name of the timelog record
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Order number of the timelog category in category list
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Timelog category is hidden
        /// </summary>
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
    }
}
