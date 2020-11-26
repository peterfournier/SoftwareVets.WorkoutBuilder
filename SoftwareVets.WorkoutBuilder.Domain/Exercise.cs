using System;
using System.Collections.Generic;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Exercise : VersionedDomainModelBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Round Round { get; set; }

        public List<Set> Sets { get; set; }

        public Exercise(Round round, string exerciseName)
        {
            Name = string.IsNullOrWhiteSpace(exerciseName) ? throw new ArgumentNullException(nameof(exerciseName)) : exerciseName;
            Round = round == null ? throw new ArgumentNullException(nameof(round)) : round;

            addDefaultSet();
        }

        private void addDefaultSet()
        {
            Sets = new List<Set>()
            {
                new Set(this, new TimeSpan(0,0,30))
                {

                }
            };
        }
    }
}
