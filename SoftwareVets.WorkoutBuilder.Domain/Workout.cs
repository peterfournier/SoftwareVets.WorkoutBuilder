using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Workout : VersionedDomainModelBase
    {
        public List<Round> Rounds { get; set; }
        public Plan Plan { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }

        public Workout([NotNull] string workoutName)
        {
            Name = string.IsNullOrWhiteSpace(workoutName) ? throw new ArgumentNullException(nameof(workoutName)) : workoutName;

            addDefaultRound();
        }

        private void addDefaultRound()
        {
            Rounds = new List<Round>()
            {
                new Round(this, "Round 1")
                {

                }
            };
        }
    }
}
