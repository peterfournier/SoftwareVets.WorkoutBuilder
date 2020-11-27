using System;
using System.Collections.Generic;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Exercise : VersionedDomainModelBase
    {
        private List<Set> _sets = new List<Set>();

        public string Name { get; private set; }

        public string Description { get; set; }

        public Round Round { get; private set; }


        public Exercise(string exerciseName)
        {
            Name = string.IsNullOrWhiteSpace(exerciseName) ? throw new ArgumentNullException(nameof(exerciseName)) : exerciseName;
        }

        public List<Set> GetSets()
        {
            return _sets;
        }

        internal void AddSet(Set set)
        {
            _sets.Add(set);
        }

        public void SetRound(Round round)
        {
            if (round == null)
                throw new ArgumentNullException(nameof(round));

            if (Round != null)
                throw new Exception("Round cannot be set twice");

            Round = round;
        }
    }
}
