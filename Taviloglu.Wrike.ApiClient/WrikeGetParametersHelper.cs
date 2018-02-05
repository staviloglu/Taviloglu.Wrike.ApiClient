using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient
{
    public class WrikeGetParametersHelper
    {
        private List<string> _filters;
        public WrikeGetParametersHelper()
        {
            _filters = new List<string>();
        }

        public void AddFilterIfNotNull(string parameterName, int? parameterValue)
        {

            if (parameterValue != null && parameterValue > 0)
            {
                _filters.Add($"{parameterName}={parameterValue}");
            }
        }

        public void AddFilterIfNotNull(string parameterName, bool? parameterValue)
        {
            if (parameterValue != null && parameterValue.Value == true)
            {
                _filters.Add($"{parameterName}=true");
            }
        }

        public void AddFilterIfNotNull(string parameterName, string parameterValue)
        {
            if (!string.IsNullOrWhiteSpace(parameterValue))
            {
                _filters.Add($"{parameterName}={parameterValue}");
            }
        }

        public void AddFilterIfNotNull<TEnum>(string parameterName, Nullable<TEnum> parameterValue) where TEnum : struct, IConvertible, IFormattable
        {
            if (parameterValue.HasValue)
            {
                _filters.Add($"{parameterName}={parameterValue}");
            }
        }

        public void AddFilterIfNotNull(string parameterName, List<string> parameterValue)
        {
            if (parameterValue!=null && parameterValue.Count>0)
            {
                _filters.Add($"{parameterName}={JsonConvert.SerializeObject(parameterValue)}");
            }
        }

        public void AddFilterIfNotNull(string parameterName, object parameterValue, JsonConverter jsonConverter=null)
        {
            if (parameterValue != null)
            {
                if (jsonConverter != null)
                {
                    _filters.Add($"{parameterName}={JsonConvert.SerializeObject(parameterValue, jsonConverter)}");
                }
                else
                {
                    _filters.Add($"{parameterName}={JsonConvert.SerializeObject(parameterValue)}");
                }
            }
        }

        public string GetFilterParametersText()
        {
            if (_filters.Count > 0)
            {
                return "?" + string.Join("&", _filters);
            }

            return string.Empty;
        }
    }
}
