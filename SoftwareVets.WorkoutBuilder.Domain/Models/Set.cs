using System;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Set : VersionedDomainModelBase
    {
        public TimeSpan Length { get; private set; }
        public int Reps { get; private set; }
        public decimal Weight { get; private set; }
        public Exercise Exercise { get; private set; }

        public Set(Exercise exercise,
                   TimeSpan setLength) : this(exercise)
        {
            Length = setLength.TotalMilliseconds == 0 ? throw new ArgumentOutOfRangeException(nameof(setLength)) : setLength;
        }

        public Set(Exercise exercise, 
                   int reps) : this(exercise)
        {
            Reps = reps < 1 ? throw new ArgumentOutOfRangeException(nameof(reps)) : reps;
        }

        private Set(Exercise exercise)
        {
            Exercise = exercise == null ? throw new ArgumentNullException(nameof(exercise)) : exercise;
        }

        public void AddWeight(decimal weight)
        {
            if (weight > 0)
            {
                Weight = weight;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Adding weight must be greater than zero.");
            }

        }
    }
}
