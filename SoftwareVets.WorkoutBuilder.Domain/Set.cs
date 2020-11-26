using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Set : VersionedDomainModelBase
    {
        public TimeSpan Length { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public Exercise Exercise { get; set; }
    }
}
