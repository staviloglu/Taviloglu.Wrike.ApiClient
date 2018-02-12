using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeException : Exception
    {
        public WrikeException(string error, string errorDescription) : base($"{error}: {errorDescription}") { }
    }
}
