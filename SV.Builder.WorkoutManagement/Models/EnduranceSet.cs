using System;

namespace SV.Builder.Domain
{
    internal class EnduranceSet : ExerciseSet, IEnduranceSet
    {
        public delegate void DurationChanged(TimeSpan duration);
        public event DurationChanged OnDurationChanged;

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get => _duration;
            private set
            {
                _duration = value;
                OnDurationChanged?.Invoke(_duration);
            }
        }

        public EnduranceSet(TimeSpan duration)
        {
            Duration = duration.TotalMilliseconds <= 0 ? throw new ArgumentOutOfRangeException(nameof(duration)) : duration;
        }

        public void ChangedDuration(TimeSpan newDuration)
        {
            if (newDuration.TotalSeconds <= 0)
                throw new ArgumentOutOfRangeException(nameof(newDuration));

            Duration = newDuration;
        }
    }
}
