using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public abstract class WrikeObject
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}
