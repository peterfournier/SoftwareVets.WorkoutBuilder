using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Builder.Core.WorkoutManagement
{
    public class Round : Entity
    {
        public virtual string Name { get; private set; }
        public virtual string Description { get; private set; }
        public virtual int Iterations { get; private set; }
        public virtual Duration EstimatedDuration { get; private set; } = Duration.None;

        public virtual Workout Workout { get; }

        private IList<Exercise> _exercises = new List<Exercise>();
        public virtual IReadOnlyList<Exercise> Exercises => _exercises.ToList();

        protected Round() { }
        public Round(
            Workout workout,
            string name,
            string description,
            int iterations
            ) : base(Guid.NewGuid())
        {
            Workout = workout;
            Update(name, description, iterations);
        }

        public void Update(string name, string description, int iterations)
        {
            Name = Guard.ForNullOrEmpty(name, nameof(name));
            Description = Guard.ForNullOrEmpty(description, nameof(description));
            Iterations = Guard.ForLessThanOne(iterations, nameof(iterations));
        }

        internal virtual void AddExercise(Exercise exercise)
        {
            EstimatedDuration += exercise.EstimatedDuration;
            _exercises.Add(exercise);
        }
    }
}
