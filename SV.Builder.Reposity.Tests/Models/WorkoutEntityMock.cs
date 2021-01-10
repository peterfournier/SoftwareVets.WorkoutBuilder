using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Repository.IntegrationTests.Models
{
    class WorkoutEntityMock : IdentityModel<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public WorkoutEntityMock()
        {
            generateRandomID();
        }

        private void generateRandomID()
        {
            if (ID == 0)
            {
                ID = Guid.NewGuid().GetHashCode();
            }
        }
    }
}
