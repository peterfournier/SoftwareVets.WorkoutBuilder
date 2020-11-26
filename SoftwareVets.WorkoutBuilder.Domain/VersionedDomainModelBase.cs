using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class VersionedDomainModelBase : DomainModelBase
    {
        public string Versions { get; set; }
    }
}
