using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// 
    /// </summary>
    public class WrikeClientIdListParameter
    {
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

            var wrikeClientIdParameterList = new List<WrikeClientIdParameter>();
            foreach (var id in idList)
            {
                wrikeClientIdParameterList.Add(new WrikeClientIdParameter(id));
            }

            Values = wrikeClientIdParameterList;
        }

        public static implicit operator List<string>(WrikeClientIdListParameter idList)
        {
            if (idList == null)
            {
                throw new ArgumentNullException(nameof(idList));
            }

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


        /// <summary>
        /// 
        /// </summary>
        public List<WrikeClientIdParameter> Values { get; private set; }

        /// <summary>
        /// Returns a string that has Ids comma seperated
        /// </summary>
        public override string ToString()
        {
            return string.Join(",", Values);
        }
    }

}
