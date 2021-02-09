using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.WorkoutManagement
{
    public class ExerciseSet
    {
        public int Reps { get; private set; }
        public Guid ExerciseId { get; private set; }

        public ExerciseSet(Guid exerciseId)
        {
            ExerciseId = exerciseId.Equals(default(Guid)) ? throw new ArgumentException(nameof(exerciseId)) : exerciseId;
        }

        public int SetReps(int numberOfReps)
        {
            if (numberOfReps < 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfReps));

            Reps = numberOfReps;

            return Reps;
        }
    }
}
