using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public class CompanyService : ITransactionalService<CompanyOperationDto, CompanyDto>, ICompanyService
    {
        public CompanyService(RepositoryContext repositoryContext,
            IMapper mapper)
        {
            _mapper = mapper;
            _repositoryContext = repositoryContext;
        }

        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public CompanyDto Add(CompanyOperationDto operation)
        {
            var contactDataEntities = GetContactData(operation.ContactData);
            var company = new Company()
            {
                Name = operation.Name,
                Address = operation.Address,
                City = operation.City,
                ContactData = contactDataEntities,
                Voivodeship = operation.Voivodeship
            };
            return _mapper.Map<Company, CompanyDto>(_repositoryContext.CompanyRepository.Add(company));
        }

        public void Delete(Guid id)
        {
            var company = GetCompany(id);
            _repositoryContext.CompanyRepository.Remove(company);
        }

        public CompanyDto GetById(Guid id)
        {
            var company = GetCompany(id);
            return _mapper.Map<Company, CompanyDto>(company);
        }

        public List<CompanyDto> GetList()
        {
            return _mapper.Map<List<Company>, List<CompanyDto>>(_repositoryContext.CompanyRepository.GetAll().ToList());
        }

        public CompanyDto Update(Guid id, CompanyOperationDto operation)
        {
            var company = GetCompany(id);
            company.Name = operation.Name;
            company.Address = operation.Address;
            company.City = operation.City;
            company.Voivodeship = operation.Voivodeship;
            company.ContactData.Clear();
            foreach (var companyContactData in GetContactData(operation.ContactData))
            {
                company.ContactData.Add(companyContactData);
            }
            return _mapper.Map<Company, CompanyDto>(_repositoryContext
                .CompanyRepository.Update(company));
        }

        public List<CompanyDto> SearchByName(string partialName)
        {
            return _mapper.Map<List<Company>, List<CompanyDto>>(_repositoryContext.CompanyRepository
                .GetAll()
                .Where(material => material.Name.Contains(partialName))
                .ToList());
        }

        private Company GetCompany(Guid id)
        {
            return _repositoryContext.CompanyRepository.GetById(id) ?? throw new NotFoundException("company");
        }

        private static List<CompanyContactData> GetContactData(IEnumerable<CompanyContactDataOperationDto> contactData)
        {
            return contactData.Select(
                e => new CompanyContactData()
                {
                    Description = e.Description,
                    EmailAddress = e.EmailAddress,
                    PhoneNumber = e.PhoneNumber,
                    RepresentativeNameAndSurname = e.RepresentativeNameAndSurname
                }
            ).ToList();
        }
    }
}