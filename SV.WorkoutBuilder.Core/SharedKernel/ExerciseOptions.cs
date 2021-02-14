using SV.Builder.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Core.SharedKernel
{
    public class ExerciseOptions : ValueObject<ExerciseOptions>
    {

        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<SetOptions> SetOptions { get; }

        public ExerciseOptions(string exerciseName,
           string exerciseDescription,
            List<SetOptions> setOptions
           )
        {
            SetOptions = setOptions;
            Name = exerciseName;
            Description = exerciseDescription;
        }

        protected override bool EqualsCore(ExerciseOptions other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
