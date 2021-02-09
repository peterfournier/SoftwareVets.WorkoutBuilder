using System;
using System.Collections.Generic;

namespace SV.Builder.Domain
{
    internal class Exercise : DomainModelBase, IExercise
    {
        private List<ExerciseSet> _sets = new List<ExerciseSet>();

        public delegate void SetAddedHandler(ExerciseSet set);
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

        public List<ExerciseSet> GetSets()
        {
            return _sets;
        }

        public void AddSet(ExerciseSet set)
        {
            set.SetExercise(this);

            if (set is EnduranceSet enduranceSet)
                enduranceSet.OnDurationChanged += Set_OnDurationChanged;

            _sets.Add(set);

            OnSetAdded?.Invoke(set);
        }

        public void AddSet(IExerciseSet set)
        {
            this.AddSet(set as ExerciseSet);
        }

        private void Set_OnDurationChanged(TimeSpan duration)
        {
            OnSetLengthChanged?.Invoke(duration);
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
