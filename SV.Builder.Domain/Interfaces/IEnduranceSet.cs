using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain
{
    public interface IEnduranceSet : IExerciseSet
    {
        TimeSpan Length { get; }
    }
}
