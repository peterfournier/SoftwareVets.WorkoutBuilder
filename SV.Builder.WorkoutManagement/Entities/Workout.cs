using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SV.Builder.WorkoutManagement
{
    public sealed class Workout : Entity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; internal set; }

        private List<Round> _rounds = new List<Round>();
        public IEnumerable<Round> Rounds
        {
            get { return _rounds; }
            private set
            {
                _rounds = value.ToList();
            }
        }

        public Workout([NotNull] string workoutName)
        {
            Name = string.IsNullOrWhiteSpace(workoutName) ? throw new ArgumentNullException(nameof(workoutName)) : workoutName;
        }

        /// For EF ONLY
        public Workout()
        {

        }

        private void Round_OnDurationChanged(TimeSpan duration)
        {
            CalulateWorkoutDuration();
        }

        private void CalulateWorkoutDuration()
        {
            Duration = new TimeSpan();

            foreach (var round in _rounds)
            {
                Duration = Duration.Add(round.Duration);
            }
        }

        public void AddRound(Round round)
        {
            if (round == null)
                throw new ArgumentNullException(nameof(round));

            _rounds.Add(round);

            round.OnDurationChanged += Round_OnDurationChanged;

            CalulateWorkoutDuration();
        }
    }
}
