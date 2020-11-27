using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Workout : VersionedDomainModelBase
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
        }

        public List<Round> GetRounds()
        {
            return _rounds;
        }
    }
}
