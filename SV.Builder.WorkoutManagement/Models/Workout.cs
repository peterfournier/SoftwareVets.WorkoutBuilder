using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SV.Builder.Domain
{
    internal class Workout : DomainModelBase, IWorkout
    {
        private List<Round> _rounds = new List<Round>();

        public string Description { get; set; }
        public string Name { get; private set; }
        public TimeSpan Duration { get; internal set; }

        public Workout([NotNull] string workoutName)
        {
            Name = string.IsNullOrWhiteSpace(workoutName) ? throw new ArgumentNullException(nameof(workoutName)) : workoutName;
        }

        
        private void Round_OnDurationChanged(TimeSpan duration)
        {
            calulateWorkoutDuration();
        }

        private void calulateWorkoutDuration()
        {
            Duration = new TimeSpan();

            foreach (var round in _rounds)
            {
                Duration = Duration.Add(round.Duration);
            }
        }

        internal void AddRound(Round round)
        {
            if (round == null)
                throw new ArgumentNullException(nameof(round));

            round.SetWorkout(this);

            _rounds.Add(round);

            round.OnDurationChanged += Round_OnDurationChanged;

            calulateWorkoutDuration();
        }

        public bool AddRound(IRound round)
        {
            int roundsBeforeAdd = _rounds.Count;

            AddRound(round as Round);

            return _rounds.Count == (roundsBeforeAdd + 1);
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                throw new ArgumentNullException(nameof(newName));

            Name = newName;
        }

        public List<IRound> GetRounds()
        {
            return _rounds.Select(x => (IRound)x)
                          .ToList();
        }
    }
}
