using System;
using System.Collections.Generic;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Exercise : VersionedDomainModelBase
    {
        private List<Set> _sets = new List<Set>();

        public delegate void SetAddedHandler(Set set);
        public event SetAddedHandler OnSetAdded;
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

        public void AddSet(Set set)
        {
            set.SetExercise(this);

            _sets.Add(set);

            OnSetAdded?.Invoke(set);
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
