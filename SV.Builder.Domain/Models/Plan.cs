using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SV.Builder.Domain
{
    internal class Plan : VersionedDomainModelBase
    {
        public string Name { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
