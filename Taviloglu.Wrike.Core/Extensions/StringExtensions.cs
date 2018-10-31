using System;

namespace Taviloglu.Wrike.Core.Extensions
{
    internal static class StringExtensions
    {
        public static void ValidateParameter(this string value, string parameterName)
        {
            EnsureNotNull(value, parameterName);

            EnsureNotEmpty(value, parameterName);
        }

        public static void EnsureNotNull(this string value, string parameterName)
        {
            if (value == null) throw new ArgumentNullException(parameterName);
        }

        public static void EnsureNotEmpty(this string value, string parameterName)
        {
            if (value.Trim() == string.Empty) throw new ArgumentException("value can not be empty", parameterName);
        }
    }
}
