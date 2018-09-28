using System;

namespace Taviloglu.Wrike.Core.Extensions
{
    internal static class StringExtensions
    {
        public static void ValidateParameter(this string value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (value.Trim() == string.Empty)
            {
                throw new ArgumentException($"value can not be empty", parameterName);
            }
        }
    }
}
