using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Builder.Core.WorkoutManagement
{
    public class Workout : Entity // aggregate root
    {
        public static Workout New = new Workout("Workout A", "A brief description of your workout");

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Duration EstimatedDuration { get; private set; } = Duration.None;

        private IList<Round> _rounds = new List<Round>();
        public virtual IReadOnlyList<Round> Rounds => _rounds.ToList();

        protected Workout() { }
        public Workout(
            string name,
            string description) : base(Guid.NewGuid())
        {
            Name = Guard.ForNullOrEmpty(name, nameof(name));
            Description = Guard.ForNullOrEmpty(description, nameof(description));
        }


        public virtual void AddRound(RoundOptions roundOptions)
        {
            if (roundOptions == null) throw new ArgumentNullException();

            var round = new Round(this, roundOptions.Name, roundOptions.Description, roundOptions.Iterations);

            foreach (var options in roundOptions.ExerciseOptions)
            {
                var exercise = new Exercise(round, options.Name, options.Description);

                foreach (var setOptions in options.SetOptions)
                {
                    var set = new Set(exercise, setOptions.Duration, setOptions.Reps, setOptions.Timed, setOptions.Type);
                    exercise.AddSet(set);
                    EstimatedDuration += set.Duration;
                }

                round.AddExercise(exercise);
            }

            _rounds.Add(round);
        }
    }
}
