using System;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Set : VersionedDomainModelBase
    {
        public TimeSpan Length { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public Exercise Exercise { get; set; }

        public Set(Exercise exercise, 
                   TimeSpan setLength) : this(exercise)
        {
            Length = setLength.TotalMilliseconds == 0 ? throw new IndexOutOfRangeException(nameof(setLength)) : setLength;
        }

        public Set(Exercise exercise, 
                   int reps) : this(exercise)
        {
            Reps = reps < 1 ? throw new IndexOutOfRangeException(nameof(reps)) : reps;
        }

        private Set(Exercise exercise)
        {
            Exercise = exercise == null ? throw new ArgumentNullException(nameof(exercise)) : exercise;
        }
    }
}
