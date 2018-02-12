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
        private string _key;
        private string _value;

        public WrikeMetadata(string key, string value)
        {
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Key should be less than 50 symbols and match following regular expression ([A-Za-z0-9_-]+)
        /// </summary>
        [JsonProperty("key")]
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                if (value.Length > 49)
                {
                    throw new ArgumentException("Key should be less than 50 characters");
                }
                if (!Regex.IsMatch(value, "([A-Za-z0-9_-]+)"))
                {
                    throw new ArgumentException("Key should match ([A-Za-z0-9_-]+)");
                }
                _key = value;
            }
        }
        /// <summary>
        /// Value should be less than 1000 symbols, compatible with JSON string. Use JSON 'null' in order to remove metadata entry
        /// </summary>
        [JsonProperty("value")]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value.Length > 999)
                {
                    throw new ArgumentException("Value should be less than 1000 characters");
                }
                _value = value;
            }
        }
    }

}
