using System;

namespace SV.Builder.WorkoutManagement.Factories
{
    public class ExerciseSetFactory
    {
        public ExerciseSet CreateSet(Guid exerciseId, Set set)
        {
            if (set.Weight > 0 && set.Duration > new TimeSpan(0,0,0))
            {
                return new IntenseEnduranceSet(exerciseId, set.Weight, set.Duration);
            }
            else if (set.Weight > 0 && set.Timed)
            {
                return new IntensePerformanceSet(exerciseId, set.Weight);
            }
            else if (set.Weight > 0)
            {
                return new StrengthSet(exerciseId, set.Weight);
            }
            else if(set.Duration > new TimeSpan(0, 0, 0))
            {
                return new EnduranceSet(exerciseId, set.Duration);
            }
            else if (set.Timed)
            {
                return new PerformanceSet(exerciseId);
            }
            return new ExerciseSet(exerciseId);
        }
    }
}
