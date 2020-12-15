using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public class MaterialService : IMaterialService
    {
        public MaterialService(IMaterialRepository materialRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialDto Add(MaterialOperationDto operation)
        {
            var material = new Material
            {
                Name = operation.Name,
                Specification = operation.Specification
            };
            return _mapper.Map<Material, MaterialDto>(_materialRepository.Add(material));
        }

        public void Delete(Guid id)
        {
            Material material = GetMaterial(id);
            _materialRepository.Remove(material);
        }

        public MaterialDto GetById(Guid id)
        {
            Material material = GetMaterial(id);
            return _mapper.Map<Material, MaterialDto>(material);
        }

        public List<MaterialDto> GetList()
        {
            List<Material> materials = _materialRepository.GetAll().ToList();
            return _mapper.Map<List<Material>, List<MaterialDto>>(materials);
        }

        public MaterialDto Update(Guid id, MaterialOperationDto operation)
        {
            Material material = GetMaterial(id);
            material.Name = operation.Name;
            material.Specification = operation.Specification;
            return _mapper.Map<Material, MaterialDto>(_materialRepository.Update(material));
        }

        private Material GetMaterial(Guid id)
        {
            return _materialRepository.GetById(id) ?? throw new NotFoundException("Material");
        }
    }
}
