using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SV.Builder.Domain
{
    internal class Workout : VersionedDomainModelBase, IWorkout
    {
        private List<Round> _rounds = new List<Round>();

        public string Description { get; set; }
        public string Name { get; private set; }
        public TimeSpan Length { get; internal set; }

        public Workout([NotNull] string workoutName)
        {
            Name = string.IsNullOrWhiteSpace(workoutName) ? throw new ArgumentNullException(nameof(workoutName)) : workoutName;
        }

        
        private void Round_OnLengthChanged(TimeSpan length)
        {
            calulateWorkoutLength();
        }

        private void calulateWorkoutLength()
        {
            Length = new TimeSpan();

            foreach (var round in _rounds)
            {
                Length = Length.Add(round.Length);
            }
        }

        internal void AddRound(Round round)
        {
            if (round == null)
                throw new ArgumentNullException(nameof(round));

            round.SetWorkout(this);

            _rounds.Add(round);

            round.OnLengthChanged += Round_OnLengthChanged;

            calulateWorkoutLength();
        }

        public void AddRound(IRound round)
        {
            AddRound(round as Round);
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
