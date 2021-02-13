using SV.WorkoutBuilder.Core.Common;
using SV.WorkoutBuilder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.WorkoutBuilder.Core.WorkoutManagement
{
    public class Workout : Entity // aggregate root
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; }
        public virtual Duration EstimatedDuration { get; private set; } = Duration.None;

        private IList<Round> _rounds = new List<Round>();
        public virtual IReadOnlyList<Round> Rounds => _rounds.ToList();

        protected Workout() { }
        public Workout(string name) : base(Guid.NewGuid())
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
        }


        public virtual void AddRound(
            string roundName,
            List<ExerciseOptions> exerciseOptions
            )
        {
            if (exerciseOptions == null) throw new ArgumentNullException();

            var round = new Round(this, roundName);

            foreach (var options in exerciseOptions)
            {
                var exercise = new Exercise(round, options.Name, options.Description);

                foreach (var setOptions in options.SetOptions)
                {
                    var set = new Set(exercise, setOptions.Duration, setOptions.Reps);
                    exercise.AddSet(set);
                    EstimatedDuration += set.Duration;
                }

                round.AddExercise(exercise);
            }

            _rounds.Add(round);
        }
    }
}
