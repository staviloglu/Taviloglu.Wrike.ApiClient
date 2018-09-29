using Newtonsoft.Json;
using System;
using Taviloglu.Wrike.Core.Extensions;

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
            letters.ValidateParameter(nameof(letters));

            if (letters.Length > 2)
            {
                throw new ArgumentException("letters can be 2 characters max.", nameof(letters));
            }

            color.ValidateParameter(nameof(color));

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
