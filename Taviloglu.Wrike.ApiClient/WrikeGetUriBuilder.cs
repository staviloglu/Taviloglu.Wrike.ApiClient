using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    internal class WrikeGetUriBuilder
    {
        private List<string> _filters;
        private string _baseUri;
        public WrikeGetUriBuilder(string baseUri)
        {
            _filters = new List<string>();
            _baseUri = baseUri;
        }

        public WrikeGetUriBuilder AddParameter(string name, object value, JsonConverter jsonConverter = null)
        {
            if (value == null)
            {
                return this;
            }

            if (value is bool)
            {
                AddBool(name, (bool)value);
                return this;
            }

            if (value is string)
            {
                AddString(name, (string)value);
                return this;
            }

            if (value is int)
            {
                AddInt(name, (int)value);
                return this;
            }

            if (value is IList)
            {
                if (((IList)value).Count > 0)
                {
                    AddList(name, (IList)value);
                }
                return this;
            }

            if (value is Enum)
            {
                AddEnum(name, (Enum)value);
                return this;
            }

            if (value is IWrikeObject)
            {
                AddWrikeObject(name, (IWrikeObject)value, jsonConverter);
                return this;
            }

            throw new ArgumentException($"{value.GetType()} is not implemented");
        }

        private void AddEnum(string parameterName, Enum parameterValue)
        {
            _filters.Add($"{parameterName}={parameterValue}");
        }

        private void AddBool(string parameterName, bool parameterValue)
        {

            _filters.Add($"{parameterName}={parameterValue.ToString().ToLower()}");
        }
        private void AddString(string parameterName, string parameterValue)
        {
            _filters.Add($"{parameterName}={parameterValue}");
        }

        private void AddInt(string parameterName, int parameterValue)
        {
            _filters.Add($"{parameterName}={parameterValue}");
        }

        private void AddList(string parameterName, IList parameterValue)
        {
            _filters.Add($"{parameterName}={JsonConvert.SerializeObject(parameterValue)}");
        }

        private void AddWrikeObject(string parameterName, IWrikeObject parameterValue, JsonConverter jsonConverter = null)
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
        public string GetUri()
        {
            if (_filters.Count > 0)
            {
                return $"{_baseUri}?{string.Join("&", _filters)}";
            }

            return _baseUri;
        }
    }
}
