using System;
using System.Collections.Generic;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Round : VersionedDomainModelBase
    {
        private List<Exercise> _exercises = new List<Exercise>();
        private Workout _workout;

        public string Name { get; private set; }
        public TimeSpan Length { get; internal set; }
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

            _exercises.Add(exercise);
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
