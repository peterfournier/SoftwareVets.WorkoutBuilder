using SV.Builder.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Core.SharedKernel
{
    public class RoundOptions : ValueObject<RoundOptions>
    {
        public string Name { get; }
        public string Description { get; }
        public int Iterations { get; }

        public IReadOnlyList<ExerciseOptions> ExerciseOptions { get; }

        public RoundOptions(string roundName,
            string description,
            int iterations,
            List<ExerciseOptions> exerciseOptions
            )
        {
            Name = Guard.ForNullOrEmpty(roundName, nameof(roundName));
            Description = description;
            Iterations = Guard.ForLessThanOne(iterations, nameof(iterations));
            ExerciseOptions = Guard.ForNull(exerciseOptions, nameof(exerciseOptions));
        }

        protected override bool EqualsCore(RoundOptions other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
