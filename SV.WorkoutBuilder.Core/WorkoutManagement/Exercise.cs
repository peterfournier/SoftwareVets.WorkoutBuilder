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
        public virtual string Name { get; }
        public virtual string Description { get; }
        public virtual Round Round { get; }

        public virtual Duration EstimatedDuration { get; private set; } = Duration.None;

        private IList<Set> _sets = new List<Set>();
        public virtual IReadOnlyList<Set> Sets => _sets.ToList();

        protected Exercise() { }
        public Exercise(Round round, 
            string name,
            string description
            ) : base(Guid.NewGuid())
        {
            Round = round;
            Name = Guard.ForNullOrEmpty(name, nameof(name));
            Description = Guard.ForNullOrEmpty(description, nameof(description));
        }

        internal virtual void AddSet(Set set)
        {
            _sets.Add(set);
            EstimatedDuration += set.Duration;
        }
    }
}
