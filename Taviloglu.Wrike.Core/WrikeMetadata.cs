using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace Taviloglu.Wrike.Core
{
    /// <summary>
    /// Metadata entry key-value pair. 
    /// Metadata entries are isolated on per-client(application) basis
    /// </summary>
    public sealed class WrikeMetadata : IWrikeObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeMetadata"/> class.
        /// </summary>
        /// <param name="key">Key should be less than 50 symbols and match following regular expression ([A-Za-z0-9_-]+)</param>
        /// <param name="value">Value should be less than 1000 symbols, compatible with JSON string. Use JSON 'null' in order to remove metadata entry</param>
        public WrikeMetadata(string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Trim() == string.Empty)
            {
                throw new ArgumentException("key should be less than 50 characters", nameof(key));
            }

            if (key.Length > 49)
            {
                throw new ArgumentException("key should be less than 50 characters",nameof(key));
            }

            if (!Regex.IsMatch(key, "([A-Za-z0-9_-]+)"))
            {
                throw new ArgumentException("key should match ([A-Za-z0-9_-]+)", nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length > 999)
            {
                throw new ArgumentException("value should be less than 1000 characters", nameof(value));
            }

            Key = key;
            Value = value;
        }
        /// <summary>
        /// Key
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; private set; }
    }
}
