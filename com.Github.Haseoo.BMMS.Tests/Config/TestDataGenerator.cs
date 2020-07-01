using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;

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

        public static CompanyContactData getContactData()
        {
            return new CompanyContactData
            {
                Description = "description",
                EmailAddress = "test@email.address",
                PhoneNumber = "123456789",
                RepresentativeNameAndSurname = "Test Testovsky"
            };
        }

        public static Company getCompany()
        {
            return new Company
            {
                Address = "Test 3/1A",
                City = "Test",
                ContactData = new List<CompanyContactData> {getContactData(), getContactData()},
                Name = "TestName",
                Voivodeship = "test"
            };
        }
    }
}