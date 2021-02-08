using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain.EntityModels
{
    public class WorkoutEntity : EntityModelBase
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; internal set; }
    }
}
