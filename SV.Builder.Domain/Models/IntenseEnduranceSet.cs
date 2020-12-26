using System;

namespace SV.Builder.Domain
{
    internal class IntenseEnduranceSet : EnduranceSet, IIntenseEnduranceSet
    {
        public double Weight { get; private set; }

        public IntenseEnduranceSet(double weight, TimeSpan duration) : base(duration)
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
