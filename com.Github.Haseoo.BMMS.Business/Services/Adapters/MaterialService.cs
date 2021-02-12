using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public class MaterialService : ITransactionalService<MaterialOperationDto, MaterialDto>, IMaterialService
    {
        public MaterialService(RepositoryContext repositoryContext,
            IMapper mapper)
        {
            _mapper = mapper;
            _repositoryContext = repositoryContext;
        }

        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;


        public MaterialDto GetById(Guid id)
        {
            var material = GetMaterial(id);
            return _mapper.Map<Material, MaterialDto>(material);
        }

        public List<MaterialDto> GetList()
        {
            return _mapper.Map<List<Material>, List<MaterialDto>>(_repositoryContext.MaterialRepository.GetAll().ToList());
        }

        public MaterialDto Update(Guid id, MaterialOperationDto operation)
        {
            var material = GetMaterial(id);
            material.Name = operation.Name;
            material.Specification = operation.Specification;
            material = _repositoryContext.MaterialRepository.Update(material);
            return _mapper.Map<Material, MaterialDto>(material);
        }

        public List<MaterialDto> SearchByName(string partialName)
        {
            return _mapper.Map<List<Material>, List<MaterialDto>>(_repositoryContext.MaterialRepository
                .GetAll()
                .Where(material => material.Name.Contains(partialName))
                .ToList());
        }

        private Material GetMaterial(Guid id)
        {
            return _repositoryContext.MaterialRepository.GetById(id) ?? throw new NotFoundException("material");
        }

        public MaterialDto Add(MaterialOperationDto operation)
        {
            var material = new Material
            {
                Name = operation.Name,
                Specification = operation.Specification
            };
            return _mapper.Map<Material, MaterialDto>(_repositoryContext.MaterialRepository.Add(material));
        }

        public void Delete(Guid id)
        {
            _repositoryContext.MaterialRepository.Remove(GetMaterial(id));
        }
    }
}