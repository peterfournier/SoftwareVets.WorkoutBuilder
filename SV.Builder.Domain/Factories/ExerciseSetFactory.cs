using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain.Factories
{
    public class ExerciseSetFactory
    {

        public IExerciseSet CreateSet(double weight, TimeSpan setLength)
        {
            if (weight > 0)
                return new StrengthSet(weight);

            return new EnduranceSet(setLength);
        }
    }
}
