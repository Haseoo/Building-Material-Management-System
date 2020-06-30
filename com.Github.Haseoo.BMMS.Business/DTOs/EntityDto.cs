using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public abstract class EntityDto
    {
        protected EntityDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}