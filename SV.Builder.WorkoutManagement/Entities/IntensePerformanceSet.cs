using System;

namespace SV.Builder.WorkoutManagement
{
    public class IntensePerformanceSet : PerformanceSet, IWeightedSet
    {
        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                setWeight(value);
            }
        }

        public IntensePerformanceSet(Guid exerciseId, double weight) : base(exerciseId)
        {
            Weight = weight;
        }

        private void setWeight(double weight)
        {
            if (weight > 0)
            {
                _weight = weight;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Adding weight must be greater than zero.");
            }
        }
    }
}
