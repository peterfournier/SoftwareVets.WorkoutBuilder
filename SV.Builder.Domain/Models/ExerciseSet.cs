using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain
{
    internal class ExerciseSet : IExerciseSet
    {
        public int Reps { get; private set; } = 1;

        public ExerciseSet()
        {

        }

        public int SetReps(int numberOfReps)
        {
            if (numberOfReps < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfReps));

            Reps = numberOfReps;

            return Reps;
        }
    }
}
