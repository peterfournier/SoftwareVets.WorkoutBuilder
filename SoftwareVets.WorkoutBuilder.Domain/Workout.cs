using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Workout : VersionedDomainModelBase
    {
        public List<Round> Rounds { get; set; }
        public Plan Plan { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }

        public Workout([NotNull] string workoutName)
        {
            Name = workoutName;
        }
    }
}
