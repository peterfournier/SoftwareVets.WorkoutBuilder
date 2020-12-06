using System;

namespace SV.Builder.Domain
{
    internal class Set : VersionedDomainModelBase
    {
        public delegate void LengthChanged(TimeSpan length);
        public event LengthChanged OnLengthChanged;

        private TimeSpan _length;
        public TimeSpan Length
        {
            get => _length;
            set
            {
                _length = value;
                OnLengthChanged?.Invoke(_length);
            }
        }
        public int Reps { get; private set; }
        public decimal Weight { get; private set; }
        public Exercise Exercise { get; private set; }

        public Set(TimeSpan setLength)
        {
            Length = setLength.TotalMilliseconds <= 0 ? throw new ArgumentOutOfRangeException(nameof(setLength)) : setLength;
        }

        public Set(int reps)
        {
            Reps = reps < 1 ? throw new ArgumentOutOfRangeException(nameof(reps)) : reps;
        }

        public void SetExercise(Exercise exercise)
        {
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));

            if (Exercise != null)
                throw new Exception("Exercise cannot be set twice");

            Exercise = exercise;
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

        public void ChangedLength(TimeSpan newTimeLength)
        {
            if (newTimeLength.TotalSeconds <= 0)
                throw new ArgumentOutOfRangeException(nameof(newTimeLength));

            Length = newTimeLength;
        }
    }
}
