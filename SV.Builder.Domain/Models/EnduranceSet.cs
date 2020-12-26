using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain
{
    internal class EnduranceSet : ExerciseSet, IEnduranceSet
    {
        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get => _duration;
            private set
            {
                _duration = value;
                //OnLengthChanged?.Invoke(_length);
            }
        }

        public EnduranceSet(TimeSpan duration)
        {
            Duration = duration.TotalMilliseconds <= 0 ? throw new ArgumentOutOfRangeException(nameof(duration)) : duration;
        }
    }
}
