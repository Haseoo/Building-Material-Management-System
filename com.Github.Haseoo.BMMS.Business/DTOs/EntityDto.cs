using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public abstract class EntityDTO
    {
        protected EntityDTO(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}