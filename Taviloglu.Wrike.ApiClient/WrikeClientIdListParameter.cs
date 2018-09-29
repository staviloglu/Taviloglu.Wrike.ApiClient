using System;
using System.Collections.Generic;
using System.Linq;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// 
    /// </summary>
    public struct WrikeClientIdListParameter
    {
        readonly List<WrikeClientIdParameter> _idList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idList"></param>
        public WrikeClientIdListParameter(List<string> idList)
        {
            if (idList == null)
            {
                throw new ArgumentNullException(nameof(idList));
            }

            if (idList.Count == 0)
            {
                throw new ArgumentException($"value can not be empty", nameof(idList));
            }

            if (idList.Count > 100)
            {
                throw new ArgumentException($"value can contain 100 items max.", nameof(idList));
            }

            if (idList.Any(s=> s == null))
            {
                throw new ArgumentNullException(nameof(idList),"value can not contain null values");
            }

            if (idList.Any(s => s.Trim() == string.Empty))
            {
                throw new ArgumentException("value can not contain empty values", nameof(idList));
            }

            var wrikeClientIdParameterList = new List<WrikeClientIdParameter>();
            foreach (var id in idList)
            {
                wrikeClientIdParameterList.Add(new WrikeClientIdParameter(id));
            }

            _idList = wrikeClientIdParameterList;
        }

        public static implicit operator List<string>(WrikeClientIdListParameter idList)
        {
            var retVal = new List<string>();
            foreach (var id in idList.Values)
            {
                retVal.Add(id);
            }

            return retVal;
        }

        public static implicit operator WrikeClientIdListParameter(List<string> idList)
        {
            return new WrikeClientIdListParameter(idList);
        }


        
        public List<WrikeClientIdParameter> Values {
            get
            {
                if (_idList == null || _idList.Count == 0)
                {
                    throw new ArgumentNullException("idList");
                }

                return _idList;
            }
        }

        /// <summary>
        /// Returns a string that has Ids comma seperated
        /// </summary>
        public override string ToString()
        {
            return string.Join(",", Values);
        }
    }

}
