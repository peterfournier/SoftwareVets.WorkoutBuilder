using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain
{
    public class Set
    {
        public double Weight { get; private set; }
        public TimeSpan Duration { get; private set; }
        public bool Timed { get; private set; }

        public Set() : this(0, TimeSpan.MinValue, false)
        {

        }
        public Set(double weight, TimeSpan duration, bool timed)
        {
            Weight = weight;
            Duration = duration;
            Timed = timed;
        }
    }
}
