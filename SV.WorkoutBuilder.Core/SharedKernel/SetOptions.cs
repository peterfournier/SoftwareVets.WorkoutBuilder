using SV.WorkoutBuilder.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.WorkoutBuilder.Core.SharedKernel
{
    public class SetOptions : ValueObject<SetOptions>
    {
        public Duration Duration { get; }
        public int Reps { get; }

        public SetOptions(Duration duration, int reps)
        {
            if (reps < 0) throw new ArgumentOutOfRangeException(nameof(reps));

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
