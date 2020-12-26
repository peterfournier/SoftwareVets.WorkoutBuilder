using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain
{
    internal class ExerciseSet : IExerciseSet
    {
        public int Reps { get; private set; } = 1;
        public Exercise Exercise { get; private set; }

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

        public void SetExercise(Exercise exercise)
        {
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));

            if (Exercise != null)
                throw new Exception("Exercise cannot be set twice");

            Exercise = exercise;
        }
    }
}
