using Newtonsoft.Json;
using System;

namespace Taviloglu.Wrike.Core
{
    /// <summary>
    /// Color
    /// </summary>
    public sealed class WrikeColor : IWrikeObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeColor"/> class.
        /// </summary>
        /// <param name="name">Color name</param>
        /// <param name="hex">HEX code</param>
        public WrikeColor(string name, string hex)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be emtpy", nameof(name));
            }

            if (hex == null)
            {
                throw new ArgumentNullException(nameof(hex));
                
            }

            if (hex.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be emtpy", nameof(hex));
            }

            Name = name;
            Hex = hex;
        }

        /// <summary>
        /// Color name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// HEX code
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; private set; }

        /// <summary>
        /// Color of a folder
        /// </summary>
        public enum FolderColor
        {
            None, Person, Purple1, Purple2, Purple3, Purple4, Indigo1, Indigo2, Indigo3, Indigo4, DarkBlue1, DarkBlue2, DarkBlue3, DarkBlue4, Blue1, Blue2, Blue3, Blue4, Turquoise1, Turquoise2, Turquoise3, Turquoise4, DarkCyan1, DarkCyan2, DarkCyan3, DarkCyan4, Green1, Green2, Green3, Green4, YellowGreen1, YellowGreen2, YellowGreen3, YellowGreen4, Yellow1, Yellow2, Yellow3, Yellow4, Orange1, Orange2, Orange3, Orange4, Red1, Red2, Red3, Red4, Pink1, Pink2, Pink3, Pink4, Gray1, Gray2, Gray3
        }

        /// <summary>
        /// Color of a custom status
        /// </summary>
        public enum CustomStatusColor
        {
            Brown, Red, Purple, Indigo, DarkBlue, Blue, Turquoise, DarkCyan, Green, YellowGreen, Yellow, Orange, Gray,
        }
    }

}
