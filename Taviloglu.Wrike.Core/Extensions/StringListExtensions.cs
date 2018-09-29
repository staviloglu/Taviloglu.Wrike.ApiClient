using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core.Extensions
{
    internal static class StringListExtensions
    {
        public static void ValidateParameter(this List<string> value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (value.Count == 0)
            {
                throw new ArgumentException("value can not be empty", parameterName);
            }

            if (value.Count > 100)
            {
                throw new ArgumentException("value can contain 100 items max.", parameterName);
            }
        }
    }
}
