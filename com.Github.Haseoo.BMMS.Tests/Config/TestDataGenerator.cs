using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Data.Entities;
using System;
using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Tests.Config
{
    public static class TestDataGenerator
    {
        public static Material GetMaterial()
        {
            return new Material
            {
                Name = "TestMaterial",
                Specification = "TestSpec"
            };
        }

        public static CompanyContactData GetContactData()
        {
            return new CompanyContactData
            {
                Description = "description",
                EmailAddress = "test@email.address",
                PhoneNumber = "123456789",
                RepresentativeNameAndSurname = "Test Testovsky"
            };
        }

        public static Company GetCompany()
        {
            return new Company
            {
                Address = "Test 3/1A",
                City = "Test",
                ContactData = new List<CompanyContactData> { GetContactData(), GetContactData() },
                Name = "TestName",
                Voivodeship = "test"
            };
        }

        public static Offer GetOffer(Company company, Material material)
        {
            return new Offer
            {
                Comments = "TestComments",
                Company = company,
                LastModification = new DateTime(2005, 4, 2, 21, 37, 0),
                Material = material,
                Unit = "tln",
                UnitPrice = 21M
            };
        }

        public static MaterialOperationDto GetMaterialOperationDto()
        {
            return MaterialOperationDto.Builder().Name("TestNewName").Specification("TestNewSpec").Build();
        }

        public static CompanyOperationDto GetCompanyOperationDto()
        {
            return CompanyOperationDto.Builder()
                .ContactData(CompanyContactDataOperationDto.Builder()
                    .RepresentativeNameAndSurname("TestNewName")
                    .EmailAddress("tutut@test.com")
                    .PhoneNumber("987654321")
                    .Description("new test desc")
                    .Build())
                .Address("new test address")
                .Voivodeship("new test vo")
                .Name("new test name")
                .City("new test city")
                .Build();
        }

        public static OfferOperationDto GetOfferOperationDto(Guid companyId = default(Guid),
            Guid materialId = default(Guid))
        {
            return OfferOperationDto.Builder()
                .UnitPrice(15m)
                .Unit("new testUnit")
                .Comments("new comments")
                .MaterialId(materialId)
                .CompanyId(companyId)
                .Build();
        }
    }
}