using System;

namespace SV.Builder.Domain.Factories
{
    public class ExerciseSetFactory
    {
        public IExerciseSet CreateSet(Set set)
        {
            if (set.Weight > 0)
            {
                return new StrengthSet(set.Weight);
            }
            return new ExerciseSet();
        }

        public IExerciseSet CreateSet(bool timed = false)
        {
            if (timed)
                return new PerformanceSet();

            return new ExerciseSet();
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

        public IExerciseSet CreateSet(TimeSpan duration)
        {
            return new EnduranceSet(duration);
        }
    }
}
