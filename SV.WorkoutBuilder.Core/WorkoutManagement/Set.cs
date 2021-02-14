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
        public virtual int Reps { get; }
        public virtual Duration Duration { get; }
        public virtual bool Timed { get; }

        protected Set() { }
        public Set(Exercise exercise,
            Duration duration,
            int reps,
            bool timed
            ) : base(Guid.NewGuid())
        {
            Timed = timed;
            Exercise = exercise;
            Duration = duration;
            Reps = reps;
        }
    }
}
