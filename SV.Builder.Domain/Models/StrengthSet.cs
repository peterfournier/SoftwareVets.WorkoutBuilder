using System;

namespace SV.Builder.Domain
{
    internal class StrengthSet : ExerciseSet, IWeightedSet
    {
        public double Weight { get; private set; }

        public StrengthSet(double weight)
        {
            addWeight(weight);
        }


        private void addWeight(double weight)
        {
            if (weight > 0)
            {
                Weight = weight;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Adding weight must be greater than zero.");
            }
        }
    }
}
