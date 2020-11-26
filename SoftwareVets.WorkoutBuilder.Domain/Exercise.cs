using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Exercise : VersionedDomainModelBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Round Round { get; set; }

        public List<Set> Sets { get; set; }
    }
}
