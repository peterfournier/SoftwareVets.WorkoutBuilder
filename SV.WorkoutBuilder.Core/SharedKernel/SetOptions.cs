using SV.Builder.Core.Common;
using System;

namespace SV.Builder.Core.SharedKernel
{
    public class SetOptions : ValueObject<SetOptions>
    {
        public Duration Duration { get; }
        public int Reps { get; }
        public bool Timed { get; }

        public SetOptions(
            Duration duration, 
            int reps,
            bool timed = false
            )
        {
            if (reps < 0) throw new ArgumentOutOfRangeException(nameof(reps));

            if (timed && duration != Duration.None) throw new ArgumentOutOfRangeException(nameof(duration));

            Timed = timed;
            Duration = duration;
            Reps = reps;
        }

        protected override bool EqualsCore(SetOptions other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
