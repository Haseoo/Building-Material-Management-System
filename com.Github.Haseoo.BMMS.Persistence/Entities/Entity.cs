using System;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}