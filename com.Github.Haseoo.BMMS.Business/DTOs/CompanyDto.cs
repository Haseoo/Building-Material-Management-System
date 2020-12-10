using com.Github.Haseoo.BMMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public sealed class CompanyDto : EntityDto
    {
        private CompanyDto(Guid id,
            string name,
            string address,
            string voivodeship,
            string city,
            IList<CompanyContactDataDto> contactData) : base(id)
        {
            Name = name;
            Address = address;
            Voivodeship = voivodeship;
            City = city;
            ContactData = contactData;
        }

        public string Name { get; }
        public string Address { get; }
        public string Voivodeship { get; }
        public string City { get; }
        public IList<CompanyContactDataDto> ContactData { get; }

        public static CompanyDto From(Company company)
        {
            return new CompanyDto(company.Id,
                company.Name,
                company.Address,
                company.Voivodeship,
                company.City,
                company.ContactData
                .Select(CompanyContactDataDto.From)
                .ToList());
        }

        public static CompanyDto Foo()
        {
            return new CompanyDto(Guid.NewGuid(), $"xDDS{Guid.NewGuid()}", "Nono", "bum bum", "xDDD", null);
        }
    }
}