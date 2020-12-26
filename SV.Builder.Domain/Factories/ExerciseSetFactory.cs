using System;

namespace SV.Builder.Domain.Factories
{
    public class ExerciseSetFactory
    {
        public IExerciseSet CreateSet()
        {
            return new PerformanceSet();
        }

        public IExerciseSet CreateSet(double weight, bool timed = false)
        {
            if (timed)
                return new IntensePerformanceSet(weight);

            return new StrengthSet(weight);
        }

        public IExerciseSet CreateSet(double weight, TimeSpan duration)
        {
            return new IntenseEnduranceSet(weight, duration);
        }

        public IExerciseSet CreateSet(TimeSpan setLength)
        {
            return new EnduranceSet(setLength);
        }
    }
}
