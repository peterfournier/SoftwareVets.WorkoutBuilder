using SV.WorkoutBuilder.Core.Common;
using SV.WorkoutBuilder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.WorkoutBuilder.Core.WorkoutManagement
{
    public class Set : Entity
    {
        public virtual Exercise Exercise { get; }
        public virtual int Reps { get; }
        public virtual Duration Duration { get; }

        protected Set() { }
        public Set(Exercise exercise,
            Duration duration,
            int reps
            ) : base(Guid.NewGuid())
        {
            Exercise = exercise;
            Duration = duration;
            Reps = reps;
        }
    }
}
