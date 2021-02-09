using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Builder.WorkoutManagement
{
    public class Round : Entity
    {

        public delegate void DurationChanged(TimeSpan duration);
        public event DurationChanged OnDurationChanged;

        public string Name { get; private set; }
        private TimeSpan _length;
        public TimeSpan Duration // todo, create a duration class
        {
            get => _length;
            set
            {
                _length = value;
                OnDurationChanged?.Invoke(_length);
            }
        }
        public int Iterations { get; set; }
        public string Description { get; set; }
        public Guid WorkoutId { get; private set; }

        private List<Exercise> _exercises = new List<Exercise>();
        public IEnumerable<Exercise> Exercises
        {
            get { return _exercises; }
            private set { _exercises = value.ToList(); }
        }

        public Round(Guid workoutId, string roundName)
        {
            WorkoutId = workoutId.Equals(default(Guid)) ? throw new ArgumentException(nameof(workoutId)) : workoutId;
            Name = string.IsNullOrWhiteSpace(roundName) ? throw new ArgumentNullException(nameof(roundName)) : roundName;
        }

        public void AddExercise(Exercise exercise)
        {
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));

            exercise.OnSetAdded += Exercise_OnSetAdded;
            exercise.OnSetLengthChanged += Exercise_OnSetLengthChanged;

            _exercises.Add(exercise);

            CalulateRoundLength();
        }

        private void Exercise_OnSetLengthChanged(TimeSpan length)
        {
            CalulateRoundLength();
        }

        private void Exercise_OnSetAdded(ExerciseSet exerciseSet)
        {
            CalulateRoundLength();
        }

        private void CalulateRoundLength()
        {
            Duration = new TimeSpan();
            foreach (var exercise in _exercises)
            {
                foreach (var set in exercise.ExerciseSets)
                {
                    if (set is EnduranceSet enduranceSet)
                        Duration = Duration.Add(enduranceSet.Duration);
                }
            }
        }
    }
}
