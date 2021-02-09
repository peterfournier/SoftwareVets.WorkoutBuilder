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

        public Set() : this(0, new TimeSpan(0,0,0), false)
        {

        }
        public Set(double weight = 0, TimeSpan duration = new TimeSpan(), bool timed = false)
        {
            if (duration > new TimeSpan(0,0,0) && timed)
                throw new ArgumentOutOfRangeException($"When the duration is set, the set cannot also be timed." +
                    $" Either set timed to false or remove the set duration.");

            Weight = weight;
            Duration = duration;
            Timed = timed;
        }
    }
}
