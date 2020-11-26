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
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public int Iterations { get; set; }
        public string Description { get; set; }
        public Workout Workout { get; set; }
        public List<Exercise> Exercises { get; set; }

        public Round(Workout workout, string roundName)
        {
            Name = string.IsNullOrWhiteSpace(roundName) ? throw new ArgumentNullException(nameof(roundName)) : roundName;
            Workout = workout == null ? throw new ArgumentNullException(nameof(workout)) : workout;

            addDefaultExercise();
        }

        private void addDefaultExercise()
        {
            Exercises = new List<Exercise>()
            {
                new Exercise(this, "Exercise 1")
                {

                }
            };
        }
    }
}
