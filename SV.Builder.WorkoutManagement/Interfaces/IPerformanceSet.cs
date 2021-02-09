using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain
{
    public interface IPerformanceSet : IExerciseSet
    {
        void Reset();
        void Start();
        void Stop();
        TimeSpan ElapsedTime { get; }
    }
}
