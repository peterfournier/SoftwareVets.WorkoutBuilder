using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SV.Builder.Domain
{
    internal class Workout : VersionedDomainModelBase, IWorkout
    {
        private List<Round> _rounds = new List<Round>();

        public Plan Plan { get; private set; }
        public string Description { get; set; }
        public string Name { get; private set; }
        public TimeSpan Length { get; internal set; }

        public Workout([NotNull] string workoutName)
        {
            Name = string.IsNullOrWhiteSpace(workoutName) ? throw new ArgumentNullException(nameof(workoutName)) : workoutName;
        }
        
        public void AddRound(Round round)
        {
            if (round == null)
                throw new ArgumentNullException(nameof(round));

            round.SetWorkout(this);

            _rounds.Add(round);

            round.OnLengthChanged += Round_OnLengthChanged;

            calulateWorkoutLength();
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

        public List<Round> GetRounds()
        {
            return _rounds;
        }
    }
}
