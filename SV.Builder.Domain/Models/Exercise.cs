using System;
using System.Collections.Generic;

namespace SV.Builder.Domain
{
    internal class Exercise : VersionedDomainModelBase, IExercise
    {
        private List<Set> _sets = new List<Set>();

        public delegate void SetAddedHandler(Set set);
        public delegate void SetLengthChangedHandler(TimeSpan length);

        public event SetAddedHandler OnSetAdded;
        public event SetLengthChangedHandler OnSetLengthChanged;

        public string Name { get; set; }
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

            set.OnLengthChanged += Set_OnLengthChanged;

            _sets.Add(set);

            OnSetAdded?.Invoke(set);
        }

        private void Set_OnLengthChanged(TimeSpan length)
        {
            OnSetLengthChanged?.Invoke(length);
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
