using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SV.Builder.WorkoutManagement
{
    public class PerformanceSet : ExerciseSet
    {
        private readonly Stopwatch _stopwatch;

        public TimeSpan ElapsedTime { get; private set; }

        public PerformanceSet(Guid exerciseId) : base(exerciseId)
        {
            _stopwatch = new Stopwatch();
        }

        public void Start()
        {
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
            ElapsedTime = new TimeSpan(_stopwatch.ElapsedTicks);
        }

        public void Reset()
        {
            _stopwatch.Reset();
            ElapsedTime = new TimeSpan(_stopwatch.ElapsedTicks);
        }
    }
}
