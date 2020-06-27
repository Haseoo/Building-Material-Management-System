using System;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class Entity
    {
        public Entity(Guid id)
        {
            Id = id;
        }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        virtual public Guid Id { get; set; }
    }
}