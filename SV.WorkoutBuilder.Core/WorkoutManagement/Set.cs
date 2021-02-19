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
        public virtual int Reps { get; } = 1;
        public virtual decimal Weight { get; }
        public virtual Duration Duration { get; }
        public virtual bool Timed { get; }
        public virtual SetType Type { get; set; }
        public bool MaxSet => Reps < 1;
        protected Set() { }
        public Set(Exercise exercise,
            Duration duration,
            int reps,
            decimal weight,
            bool timed,
            SetType type
            ) : base(Guid.NewGuid())
        {
            Weight = weight;
            Timed = timed;
            Exercise = exercise;
            Duration = duration;
            Reps = reps;
            Type = type;
        }
    }
}
