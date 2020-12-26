using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain.Factories
{
    public class ExerciseSetFactory
    {

        public IExerciseSet CreateSet()
        {
            return new PerformanceSet();
        }

        public IExerciseSet CreateSet(double weight)
        {
            return new StrengthSet(weight);
        }

        public IExerciseSet CreateSet(TimeSpan setLength)
        {
            return new EnduranceSet(setLength);
        }
    }
}
