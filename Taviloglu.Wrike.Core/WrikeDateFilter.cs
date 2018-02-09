using Newtonsoft.Json;
using System;

namespace Taviloglu.Wrike.Core
{
    /// <summary>
    /// Date exact match or semi-open interval
    /// </summary>
    public class WrikeDateFilterEqual : IWrikeDateFilterEqual
    {
        
        /// <summary>
        /// Date exact match value 
        /// </summary>
        [JsonProperty(PropertyName = "equal",
                DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Equal { get; set; }
        
        public WrikeDateFilterEqual(DateTime equal) {
            Equal = equal;
        }       
    }

    /// <summary>
    /// Timestamp semi-open interval
    /// </summary>
    public class WrikeDateFilterRange  : IWrikeDateFilterRange
    {
        /// <summary>
        /// Range start 
        /// </summary>
        [JsonProperty(PropertyName = "start",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Start { get; set; }

        /// <summary>
        /// Range end 
        /// </summary>
        [JsonProperty(PropertyName = "end",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime End { get; set; }

        public WrikeDateFilterRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }

    public interface IWrikeDateFilterRange : IWrikeDateFilter {
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
    public interface IWrikeDateFilterEqual : IWrikeDateFilter {
        DateTime Equal { get; set; }
    }
    public interface IWrikeDateFilter : IWrikeObject { }
}
