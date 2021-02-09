using System;

namespace SV.Builder.WorkoutManagement
{
    public abstract class Entity : GraniteCore.BaseDomainModel<Guid>
    {
        public Entity(Guid guid)
        {
            // todo: test for this
            if (guid.Equals(default(Guid)))
                throw new ArgumentException(nameof(guid));

            ID = guid;
        }

        public Entity() : this(Guid.NewGuid())// statisfy EF Core
        {

        }
    }
}
