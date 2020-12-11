using System;
using System.Collections.Generic;

namespace SV.Builder.Domain
{
    internal class Round : VersionedDomainModelBase, IRound
    {
        private List<Exercise> _exercises = new List<Exercise>();
        private Workout _workout;

        public delegate void LengthChanged(TimeSpan length);
        public event LengthChanged OnLengthChanged;

        public string Name { get; private set; }
        private TimeSpan _length;
        public TimeSpan Length
        {
            get => _length;
            set
            {
                _length = value;
                OnLengthChanged?.Invoke(_length);
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

        private void Exercise_OnSetAdded(Set set)
        {
            calulateRoundLength();
        }

        private void calulateRoundLength()
        {
            Length = new TimeSpan();
            foreach (var exercise in _exercises)
            {
                foreach (var set in exercise.GetSets())
                {
                    Length = Length.Add(set.Length);
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
    }
}
