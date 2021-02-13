using SV.WorkoutBuilder.Core.Common;
using SV.WorkoutBuilder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.WorkoutBuilder.Core.WorkoutManagement
{
    public class Round : Entity
    {
        public virtual string Name { get; }
        public virtual string Description { get; }
        public virtual Duration EstimatedDuration { get; private set; } = Duration.None;

        public virtual Workout Workout { get; }

        private IList<Exercise> _exercises = new List<Exercise>();
        public virtual IReadOnlyList<Exercise> Exercises => _exercises.ToList();

        protected Round() { }
        public Round(Workout workout, string name) : base(Guid.NewGuid())
        {
            Workout = workout;
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
        }

        internal virtual void AddExercise(Exercise exercise)
        {
            EstimatedDuration += exercise.EstimatedDuration;
            _exercises.Add(exercise);
        }
    }
}
