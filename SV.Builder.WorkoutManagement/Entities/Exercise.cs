using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Builder.WorkoutManagement
{
    public class Exercise : Entity
    {
        private List<ExerciseSet> _sets = new List<ExerciseSet>();

        public delegate void SetAddedHandler(ExerciseSet set);
        public delegate void SetLengthChangedHandler(TimeSpan length);

        public event SetAddedHandler OnSetAdded;
        public event SetLengthChangedHandler OnSetLengthChanged;

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid RoundId { get; private set; }

        public IEnumerable<ExerciseSet> ExerciseSets
        {
            get { return _sets; }
            private set { _sets = value.ToList(); }
        }

        public Exercise(Guid roundId, string exerciseName)
        {
            RoundId = roundId.Equals(default(Guid)) ? throw new ArgumentException(nameof(roundId)) : roundId;
            Name = string.IsNullOrWhiteSpace(exerciseName) ? throw new ArgumentNullException(nameof(exerciseName)) : exerciseName;
        }

        public void AddSet(ExerciseSet set)
        {
            if (set is EnduranceSet enduranceSet)
                enduranceSet.OnDurationChanged += Set_OnDurationChanged;

            _sets.Add(set);

            OnSetAdded?.Invoke(set);
        }

        private void Set_OnDurationChanged(TimeSpan duration)
        {
            OnSetLengthChanged?.Invoke(duration);
        }
    }
}
