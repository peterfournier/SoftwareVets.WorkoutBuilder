using System;

namespace SV.Builder.Domain
{
    internal class IntensePerformanceSet : PerformanceSet, IIntensePerformanceSet
    {
        public double Weight { get; private set; }

        public IntensePerformanceSet(double weight)
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
