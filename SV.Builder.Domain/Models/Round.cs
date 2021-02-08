using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Builder.Domain
{
    internal class Round : DomainModelBase, IRound
    {
        private List<Exercise> _exercises = new List<Exercise>();
        private Workout _workout;

        public delegate void DurationChanged(TimeSpan duration);
        public event DurationChanged OnDurationChanged;

        public string Name { get; private set; }
        private TimeSpan _length;
        public TimeSpan Duration
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
        public Workout Workout => _workout;


        public Round(string roundName)
        {
            Name = string.IsNullOrWhiteSpace(roundName) ? throw new ArgumentNullException(nameof(roundName)) : roundName;
        }

        public void AddExercise(Exercise exercise)
        {
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));

            exercise.SetRound(this);

            exercise.OnSetAdded += Exercise_OnSetAdded;
            exercise.OnSetLengthChanged += Exercise_OnSetLengthChanged;

            _exercises.Add(exercise);

            calulateRoundLength();
        }

        private void Exercise_OnSetLengthChanged(TimeSpan length)
        {
            calulateRoundLength();
        }

        private void Exercise_OnSetAdded(ExerciseSet exerciseSet)
        {
            calulateRoundLength();
        }

        private void calulateRoundLength()
        {
            Duration = new TimeSpan();
            foreach (var exercise in _exercises)
            {
                foreach (var set in exercise.GetSets())
                {
                    if (set is EnduranceSet enduranceSet)
                        Duration = Duration.Add(enduranceSet.Duration);
                }
            }
        }

        public List<Exercise> GetExercises()
        {
            return _exercises;
        }

        public void SetWorkout(Workout workout)
        {
            if (workout == null)
                throw new ArgumentNullException(nameof(workout));

            if (_workout != null)
                throw new Exception("Workout can only be set once");

            _workout = workout;
        }

        public bool AddExercise(IExercise exercise)
        {
            int initialRoundCount = _exercises.Count;

            AddExercise(exercise as Exercise);
            
            return _exercises.Count == (initialRoundCount + 1);
        }

        IList<IExercise> IRound.GetExercises()
        {
            return _exercises.Select(x => x as IExercise)
                             .ToList();
        }
    }
}
