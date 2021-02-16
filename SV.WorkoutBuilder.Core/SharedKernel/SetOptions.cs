using SV.Builder.Core.Common;
using System;

namespace SV.Builder.Core.SharedKernel
{
    public class SetOptions : ValueObject<SetOptions>
    {
        public Duration Duration { get; } = Duration.None;
        public int Reps { get; }
        public bool Timed { get; }
        public decimal Weight { get; }
        public SetType Type { get; private set; }

        public SetOptions(
            Duration duration,
            int reps,
            decimal weight = 0,
            bool timed = false
            )
        {
            if (reps < 0) throw new ArgumentOutOfRangeException(nameof(reps));

            if (timed && duration != Duration.None) throw new ArgumentOutOfRangeException(nameof(duration));

            Timed = timed;
            Weight = Guard.ForLessThanZero(weight, nameof(weight));
            Duration = duration;
            Reps = reps;
            SetType();
        }

        private void SetType()
        {
            if (Weight > 0 && Duration > Duration.None)
            {
                Type = SharedKernel.SetType.StrengthEndurance;
            }
            else if (Weight > 0 && Timed)
            {
                Type = SharedKernel.SetType.StrengthPerformance;
            }
            else if (Weight > 0)
            {
                Type = SharedKernel.SetType.Strength;
            }
            else if (Duration > Duration.None)
            {
                Type = SharedKernel.SetType.Endurance;
            }
            else if (Timed)
            {
                Type = SharedKernel.SetType.Performance;
            }
            else
            {
                Type = SharedKernel.SetType.None;
            }
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
