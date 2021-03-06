﻿using com.Github.Haseoo.BMMS.Data.Entities;
using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public sealed class MaterialDto : EntityDto
    {
        private MaterialDto(Guid id, string name, string specification) : base(id)
        {
            Name = name;
            Specification = specification;
        }

        public string Name { get; }
        public string Specification { get; }

        public static MaterialDto From(Material material)
        {
            return new MaterialDto(material.Id, material.Name, material.Specification);
        }
    }
}