using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain.Factories
{
    public class ExerciseSetFactory
    {

        public IExerciseSet CreateSet(double weight)
        {
            return new StrengthSet(weight);
        }
    }
}
