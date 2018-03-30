using Newtonsoft.Json;
using System;

namespace Taviloglu.Wrike.Core
{
    /// <summary>
    /// Group avatar
    /// </summary>
    public sealed class WrikeGroupAvatar : IWrikeObject
    {
        /// <summary></summary>
        /// <param name="color"> Hex color code</param>
        /// <param name="letters">Group letters (2 symbols max)</param>
        public WrikeGroupAvatar(string color, string letters)
        {
            if (letters.Length < 2)
            {
                throw new ArgumentException("letters length can be 2 symbols max.", nameof(letters));
            }

            Color = color;
            Letters = letters;
        }

        /// <summary>
        /// Hex color code
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; private set; }

        /// <summary>
        /// Group letters (2 symbols max)
        /// </summary>
        [JsonProperty("letters")]
        public string Letters { get; private set; }
    }
}
