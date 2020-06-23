using System;
using System.Collections.Generic;
using System.Linq;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.Data.UnitTests.Data.Repositories
{
    [TestFixture]
    public class CompanyRepositoryTest
    {
        [SetUp]
        public void Init()
        {
            _testStorage = new Dictionary<Guid, Company>();
            _sut = new CompanyRepository(_testStorage);
        }

        private ICompanyRepository _sut;
        private Dictionary<Guid, Company> _testStorage;

        public static Company GetTestCompany()
        {
            var ccd = new CompanyContactData
            {
                Description = "TestDescription",
                EmailAddress = "test@test.ts",
                PhoneNumber = "123456789",
                Representative = "Test Testovsky"
            };
            return new Company
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Address = "Test address",
                ContactData = new List<CompanyContactData> {ccd}
            };
        }

        [Test]
        public void should_add_company()
        {
            //given
            var company = GetTestCompany();
            //when
            _sut.Add(company);
            //then
            var outVal = _testStorage[company.Id];
            Assert.NotNull(outVal);
            Assert.AreEqual(1, _testStorage.Keys.Count);
            Assert.AreEqual(company.Id, outVal.Id);
            Assert.AreEqual(company.Name, outVal.Name);
            Assert.AreEqual(company.Address, outVal.Address);
            Assert.AreEqual(outVal.ContactData.Count, 1);
            Assert.IsTrue(company.ContactData.SequenceEqual(outVal.ContactData));
        }

        [Test]
        public void should_remove_company()
        {
            //given
            var company = GetTestCompany();
            _testStorage.Add(company.Id, company);
            //when
            _sut.Remove(company.Id);
            //then
            Assert.IsFalse(_testStorage.ContainsKey(company.Id));
        }

        [Test]
        public void should_return_company_with_given_id()
        {
            //given
            var company = GetTestCompany();
            _testStorage.Add(company.Id, company);
            //when
            var outVal = _sut.GetById(company.Id);
            //then
            Assert.IsNotNull(outVal);
            Assert.AreEqual(company.Id, outVal.Id);
        }

        [Test]
        public void should_return_list_with_two_elements()
        {
            //given
            var company = GetTestCompany();
            _testStorage.Add(company.Id, company);
            company = GetTestCompany();
            company.Id = Guid.NewGuid();
            _testStorage.Add(company.Id, company);
            //when
            var outList = _sut.GetAll();
            //then
            Assert.AreEqual(2, outList.Count);
        }

        [Test]
        public void should_return_null_when_company_with_id_not_exist()
        {
            //given & when & then
            Assert.IsNull(_sut.GetById(Guid.NewGuid()));
        }
    }
}