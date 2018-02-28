using System;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeException : Exception
    {
        public WrikeException(string error, string errorDescription) : base($"{error}: {errorDescription}") { }
    }
}
