using System;

namespace SV.Builder.Domain.Factories
{
    public class ExerciseSetFactory
    {
        public IExerciseSet CreateSet(Set set)
        {
            if (set.Weight > 0 && set.Duration > new TimeSpan(0,0,0))
            {
                return new IntenseEnduranceSet(set.Weight, set.Duration);
            }
            else if (set.Weight > 0 && set.Timed)
            {
                return new IntensePerformanceSet(set.Weight);
            }
            else if (set.Weight > 0)
            {
                return new StrengthSet(set.Weight);
            }
            else if(set.Duration > new TimeSpan(0, 0, 0))
            {
                return new EnduranceSet(set.Duration);
            }
            else if (set.Timed)
            {
                return new PerformanceSet();
            }
            return new ExerciseSet();
        }
    }
}
