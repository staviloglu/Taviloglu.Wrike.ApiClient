using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeColor
    {
        /// <summary>
        /// Color name
        /// </summary>
       [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// HEX code
        /// </summary>
       [JsonProperty(PropertyName = "hex")]
        public string Hex { get; set; }

        public enum Value {
            None, Person, Purple1, Purple2, Purple3, Purple4, Indigo1, Indigo2, Indigo3, Indigo4, DarkBlue1, DarkBlue2, DarkBlue3, DarkBlue4, Blue1, Blue2, Blue3, Blue4, Turquoise1, Turquoise2, Turquoise3, Turquoise4, DarkCyan1, DarkCyan2, DarkCyan3, DarkCyan4, Green1, Green2, Green3, Green4, YellowGreen1, YellowGreen2, YellowGreen3, YellowGreen4, Yellow1, Yellow2, Yellow3, Yellow4, Orange1, Orange2, Orange3, Orange4, Red1, Red2, Red3, Red4, Pink1, Pink2, Pink3, Pink4, Gray1, Gray2, Gray3
        }
    }

}
