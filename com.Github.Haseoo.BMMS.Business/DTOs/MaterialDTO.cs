using System;
using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public sealed class MaterialDTO : EntityDTO
    {
        private MaterialDTO(Guid id, string name, string specification) : base(id)
        {
            Name = name;
            Specification = specification;
        }

        public string Name { get;}
        public string Specification { get; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Specification)}: {Specification}";
        }


        public static MaterialDTO from(Material material)
        {
            return  new MaterialDTO(material.Id, material.Name, material.Specification);
        }
    }
}