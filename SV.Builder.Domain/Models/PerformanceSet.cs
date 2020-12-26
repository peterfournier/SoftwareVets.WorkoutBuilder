using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SV.Builder.Domain
{
    internal class PerformanceSet : IPerformanceSet
    {
        private readonly Stopwatch _stopwatch;

        public TimeSpan ElapsedTime { get; private set; }

        public PerformanceSet()
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
