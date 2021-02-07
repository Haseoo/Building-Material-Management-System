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
    public class MaterialService : IMaterialService
    {
        public MaterialService(RepositoryContext repositoryContext,
            IMapper mapper)
        {
            _mapper = mapper;
            _repositoryContext = repositoryContext;
        }

        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public MaterialDto Add(MaterialOperationDto operation)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                var material = new Material
                {
                    Name = operation.Name,
                    Specification = operation.Specification
                };
                material = _repositoryContext.MaterialRepository.Add(material);
                transaction.Commit();
                return _mapper.Map<Material, MaterialDto>(material);
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                throw;
            }
        }

        public void Delete(Guid id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                Material material = GetMaterial(id);
                _repositoryContext.MaterialRepository.Remove(material);
                transaction.Commit();
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                throw;
            }
        }

        public MaterialDto GetById(Guid id)
        {
            Material material = GetMaterial(id);
            return _mapper.Map<Material, MaterialDto>(material);
        }

        public List<MaterialDto> GetList()
        {
            return _mapper.Map<List<Material>, List<MaterialDto>>(_repositoryContext.MaterialRepository.GetAll().ToList());
        }

        public MaterialDto Update(Guid id, MaterialOperationDto operation)
        {
            Material material = GetMaterial(id);
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
            return _repositoryContext.MaterialRepository.GetById(id) ?? throw new NotFoundException("Material");
        }
    }
}