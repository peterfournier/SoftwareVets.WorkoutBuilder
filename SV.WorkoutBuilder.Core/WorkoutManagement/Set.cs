using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Core.WorkoutManagement
{
    public class Set : Entity
    {
        public virtual Exercise Exercise { get; }
        public virtual string Name { get; }
        public virtual int Reps { get; private set; } = 1;
        public virtual decimal Weight { get; private set; }
        public virtual Duration Duration { get; private set; }
        public virtual bool Timed { get; private set; }
        public virtual SetType Type { get; private set; }
        public bool MaxSet => Reps < 1;
        protected Set() { }
        public Set(Exercise exercise,
            SetOptions options
            ) : base(Guid.NewGuid())
        {
            Name = $"Set {exercise.Sets.Count + 1}";
            Exercise = exercise;
            Update(options);
        }

        public void Update(SetOptions options)
        {
            Duration = options.Duration;
            Reps = options.Reps;
            Timed = options.Timed;
            Weight = options.Weight;
            Type = options.Type;
        }
    }
}
