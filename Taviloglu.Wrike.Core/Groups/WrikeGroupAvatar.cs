using Newtonsoft.Json;
using System;

namespace Taviloglu.Wrike.Core.Groups
{
    /// <summary>
    /// Group avatar
    /// </summary>
    public sealed class WrikeGroupAvatar : IWrikeObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeGroupAvatar"></see> class with the
        ///  color and letters parameters
        /// </summary>
        /// <param name="color"> Hex color code</param>
        /// <param name="letters">Group letters (2 symbols max)</param>
        public WrikeGroupAvatar(string color, string letters)
        {
            if (letters == null)
            {
                throw new ArgumentNullException(nameof(letters));
            }

            if (letters.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(letters));
            }

            if (letters.Length > 2)
            {
                throw new ArgumentException("letters can be 2 characters max.", nameof(letters));
            }

            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (color.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(color));
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
