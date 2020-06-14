using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    internal class WrikeUriBuilder
    {
        private readonly  List<string> _filters;
        private readonly string _baseUri;

        public WrikeUriBuilder(string baseUri)
        {
            _filters = new List<string>();
            _baseUri = baseUri;
        }

        public WrikeUriBuilder AddParameter(string name, object value, JsonConverter jsonConverter = null)
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

            var stringValue = value as string;
            if (stringValue!= null)
            {
                AddString(name, stringValue);
                return this;
            }

            if (value is int)
            {
                AddInt(name, (int)value);
                return this;
            }

            var iListValue = value as IList;
            if (iListValue != null)
            {
                if (iListValue.Count > 0)
                {
                    AddList(name, iListValue);
                }
                return this;
            }

            var enumValue = value as Enum;
            if (enumValue != null)
            {
                AddEnum(name, enumValue);
                return this;
            }

            var iWrikeObjectValue = value as IWrikeObject;
            if (iWrikeObjectValue!=null)
            {
                AddWrikeObject(name, iWrikeObjectValue, jsonConverter);
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
