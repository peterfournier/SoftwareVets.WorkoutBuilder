using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Round : VersionedDomainModelBase
    {
        private List<Exercise> _exercises;

        public string Name { get; private set; }
        public TimeSpan Length { get; private set; }
        public int Iterations { get; set; }
        public string Description { get; set; }
        public Workout Workout { get; private set; }

        public Round(Workout workout, string roundName)
        {
            Name = string.IsNullOrWhiteSpace(roundName) ? throw new ArgumentNullException(nameof(roundName)) : roundName;
            Workout = workout == null ? throw new ArgumentNullException(nameof(workout)) : workout;

            addDefaultExercise();
        }

        private void addDefaultExercise()
        {
            _exercises = new List<Exercise>()
            {
                new Exercise(this, "Exercise 1")
                {

                }
            };
        }

        public void AddExercise(Exercise exercise)
        {
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));

            _exercises.Add(exercise);
        }

        public List<Exercise> GetExercises()
        {
            return _exercises;
        }
    }
}
