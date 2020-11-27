using System;
using System.Collections.Generic;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal class Exercise : VersionedDomainModelBase
    {
        private List<Set> _sets;

        public string Name { get; private set; }

        public string Description { get; set; }

        public Round Round { get; private set; }


        public Exercise(Round round, string exerciseName)
        {
            Name = string.IsNullOrWhiteSpace(exerciseName) ? throw new ArgumentNullException(nameof(exerciseName)) : exerciseName;
            Round = round == null ? throw new ArgumentNullException(nameof(round)) : round;

            addDefaultSet();
        }

        public List<Set> GetSets()
        {
            return _sets;
        }

        private void addDefaultSet()
        {
            _sets = new List<Set>()
            {
                new Set(this, new TimeSpan(0,0,30))
                {

                }
            };
        }

        internal void AddSet(Set set)
        {
            _sets.Add(set);
        }
    }
}
