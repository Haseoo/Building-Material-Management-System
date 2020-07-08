using com.Github.Haseoo.BMMS.Data.Entities;
using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public sealed class CompanyContactDataDto : EntityDto
    {
        private CompanyContactDataDto(Guid id,
            string description,
            string representativeNameAndSurname,
            string emailAddress,
            string phoneNumber) : base(id)
        {
            Description = description;
            RepresentativeNameAndSurname = representativeNameAndSurname;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public string Description { get; }
        public string RepresentativeNameAndSurname { get; }
        public string EmailAddress { get; }
        public string PhoneNumber { get; }

        public static CompanyContactDataDto From(CompanyContactData companyContactData)
        {
            return new CompanyContactDataDto(companyContactData.Id,
                companyContactData.Description,
                companyContactData.RepresentativeNameAndSurname,
                companyContactData.EmailAddress,
                companyContactData.PhoneNumber);
        }
    }
}