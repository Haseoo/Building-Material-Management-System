using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Tests.Config;
using NHibernate.Linq;
using NUnit.Framework;
using System;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Tests.Persistence.Repositories
{
    [TestFixture]
    public class CompanyRepositoryTest : RepositoryTestSetupFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _sut = new CompanyRepository(_session);
        }

        [TearDown]
        public override void TestTeardown()
        {
            base.TestTeardown();
        }

        private CompanyRepository _sut;

        [Test]
        public void should_add_company()
        {
            //given
            var inVal = TestDataGenerator.getCompany();
            //when
            _sut.Add(inVal);
            var outVal = _session.Get<Company>(inVal.Id);
            //then
            Assert.AreEqual(inVal.Address, outVal.Address);
            Assert.AreEqual(inVal.City, outVal.City);
            Assert.AreEqual(inVal.Name, outVal.Name);
            Assert.AreEqual(inVal.Voivodeship, outVal.Voivodeship);
            CollectionAssert.AreEqual(outVal.ContactData, outVal.ContactData);
        }

        [Test]
        public void should_edit_company()
        {
            //given
            const string newName = "newName";
            const string newAddress = "newAddress";
            const string newCity = "newCity";
            var inVal = _session.Get<Company>(_session.Save(TestDataGenerator.getCompany()));
            //when
            inVal.ContactData.Add(TestDataGenerator.getContactData());
            inVal.City = newCity;
            inVal.Name = newName;
            inVal.Address = newAddress;
            _sut.Update(inVal);
            var outVal = _session.Get<Company>(inVal.Id);
            //then
            Assert.AreEqual(newName, outVal.Name);
            Assert.AreEqual(newCity, outVal.City);
            Assert.AreEqual(newAddress, outVal.Address);
            Assert.AreEqual(3, outVal.ContactData.Count);
        }

        [Test]
        public void should_remove_company()
        {
            //given
            var inVal = _session.Get<Company>(_session.Save(TestDataGenerator.getCompany()));
            //when
            _sut.Remove(inVal);
            //then
            CollectionAssert.DoesNotContain(_session.Query<Company>().ToList(), inVal);
        }

        [Test]
        public void should_return_company_by_id()
        {
            //given
            var id = _session.Save(TestDataGenerator.getCompany()).As<Guid>();
            //when
            var outVal = _sut.GetById(id);
            //then
            Assert.NotNull(outVal);
            Assert.AreEqual(id, outVal.Id);
        }

        [Test]
        public void should_return_list_with_two_elements()
        {
            //given
            _session.Save(TestDataGenerator.getCompany());
            _session.Save(TestDataGenerator.getCompany());
            //when & then
            Assert.AreEqual(2, _sut.GetAll().Count());
        }

        [Test]
        public void should_return_null_when_company_does_not_exist()
        {
            //given & when & then
            Assert.IsNull(_sut.GetById(Guid.Empty));
        }
    }
}