using System;

namespace SV.Builder.WorkoutManagement
{
    public class EnduranceSet : ExerciseSet
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

        public EnduranceSet(Guid exerciseId, TimeSpan duration) : base(exerciseId)
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
