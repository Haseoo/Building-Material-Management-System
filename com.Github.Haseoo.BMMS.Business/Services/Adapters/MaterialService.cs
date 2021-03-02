using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;

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


        public MaterialDto GetById(Guid id)
        {
            var material = GetMaterial(id);
            return _mapper.Map<Material, MaterialDto>(material);
        }

        public IList<MaterialDto> GetList()
        {
            return _mapper.Map<IList<Material>, IList<MaterialDto>>(_materialRepository.GetAll().ToList());
        }

        public MaterialDto Update(Guid id, MaterialOperationDto operation)
        {
            var material = GetMaterial(id);
            material.Name = operation.Name;
            material.Specification = operation.Specification;
            material = _materialRepository.Update(material);
            return _mapper.Map<Material, MaterialDto>(material);
        }

        public IList<MaterialDto> SearchByName(string partialName)
        {
            return _mapper.Map<IList<Material>, IList<MaterialDto>>(_materialRepository
                .GetAll()
                .Where(material => material.Name.Contains(partialName))
                .ToList());
        }

        private Material GetMaterial(Guid id)
        {
            return _materialRepository.GetById(id) ?? throw new NotFoundException("material");
        }

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
            _materialRepository.Remove(GetMaterial(id));
        }
    }
}