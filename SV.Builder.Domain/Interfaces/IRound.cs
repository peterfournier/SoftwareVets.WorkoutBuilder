using System;
using System.Collections.Generic;

namespace SV.Builder.Domain
{
    public interface IRound
    {
        public string Name { get; }
        public TimeSpan Length { get; }
        int Iterations { get; }
        string Description { get; }
        bool AddExercise(IExercise exercise);
        IList<IExercise> GetExercises();
    }
}
