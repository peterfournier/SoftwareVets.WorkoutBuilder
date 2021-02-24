using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SV.Builder.Core.WorkoutManagement
{
    public class Exercise : Entity
    {
        public static string DefaultName => "Exercise Name";
        public static string DefaultDescription => "Brief Description";

        public virtual string Name { get; private set; }
        public virtual string Description { get; private set; }
        public virtual Round Round { get; private set; }

        public virtual Duration EstimatedDuration { get; private set; } = Duration.None;

        private IList<Set> _sets = new List<Set>();
        public virtual IReadOnlyList<Set> Sets => _sets.ToList();


        protected Exercise() { }

        public Exercise(Round round) : this(round, DefaultName, DefaultDescription) { }

        public Exercise(Round round,
            string name,
            string description
            ) : base(Guid.NewGuid())
        {
            Round = round;
            Update(name, description);
        }

        public virtual void AddSet(Set set)
        {
            EstimatedDuration += set.Duration;
            _sets.Add(set);
        }

        // this is leaky
        public void Update(
            string name,
            string description)
        {
            Name = Guard.ForNullOrEmpty(name, nameof(name));
            Description = Guard.ForNullOrEmpty(description, nameof(description));
        }

        public void RemoveSet(Guid setIdToRemove)
        {
            var setToRemove =_sets.Single(x => x.Id.Equals(setIdToRemove));
            if (setIdToRemove != null)
            {
                _sets.Remove(setToRemove);
            }
        }
    }
}
