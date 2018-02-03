using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public enum WrikeUserType
    {
        /// <summary>
        /// Person
        /// </summary>
        Person,
        /// <summary>
        /// Group of users. Group userId can be used in folder/task sharing requests only. It has no effect in other operations
        /// </summary>
        Group
    }
}
