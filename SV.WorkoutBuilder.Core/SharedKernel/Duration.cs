using SV.Builder.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Core.SharedKernel
{
    public sealed class Duration : ValueObject<Duration>
    {
        public static Duration None = new Duration(0, 0, 0);
        public static Duration FiveMinutes = new Duration(0, 5, 0);
        public static Duration TenMinutes = new Duration(0, 10, 0);


        private readonly int _minutes;
        private readonly int _seconds;
        private readonly int _hours;

        public TimeSpan Length => new TimeSpan(_hours, _minutes, _seconds);

        private Duration() { }
        public Duration(int hours, int mins, int seconds)
        {
            _hours = hours;
            _minutes = mins;
            _seconds = seconds;
        }

        public static Duration operator +(Duration duration1, Duration duration2)
        {
            var duration = new Duration(
                duration1.Length.Hours + duration2.Length.Hours,
                duration1.Length.Minutes + duration2.Length.Minutes,
                duration1.Length.Seconds + duration2.Length.Seconds
                );

            return duration;
        }

        public static bool operator >(Duration duration1, Duration duration2)
        {
            if (duration1.Length.Hours > duration2.Length.Hours
                || duration1.Length.Minutes > duration2.Length.Minutes
                || duration1.Length.Seconds > duration2.Length.Seconds)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Duration duration1, Duration duration2)
        {
            if (duration1.Length.Hours < duration2.Length.Hours
                || duration1.Length.Minutes < duration2.Length.Minutes
                || duration1.Length.Seconds < duration2.Length.Seconds)
            {
                return true;
            }

            return false;
        }

        protected override bool EqualsCore(Duration other)
        {
            return Length.Hours == other.Length.Hours
                && Length.Minutes == other.Length.Minutes
                && Length.Seconds == other.Length.Seconds
                ;
        }

        protected override int GetHashCodeCore()
        {
            return Length.GetHashCode() * 397;
        }

        public override string ToString()
        {
            return Length.ToString();
        }
    }
}
