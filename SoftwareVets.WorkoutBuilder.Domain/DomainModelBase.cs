using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain
{
    internal abstract class DomainModelBase 
    {
        public Guid Id { get; set; }
    }
}
