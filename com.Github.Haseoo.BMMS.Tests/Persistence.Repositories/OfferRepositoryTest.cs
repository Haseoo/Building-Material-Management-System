using System;
using System.Linq;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Tests.Config;
using NHibernate.Linq;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.Tests.Persistence.Repositories
{
    [TestFixture]
    public class OfferRepositoryTest : RepositoryTestSetupFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _sut = new OfferRepository(new SessionWrapper(_session));
        }

        [TearDown]
        public override void TestTeardown()
        {
            base.TestTeardown();
        }

        private OfferRepository _sut;

        [Test]
        public void should_add_offer()
        {
            //given
            var material = _session.Get<Material>(_session.Save(TestDataGenerator.GetMaterial()));
            var company = _session.Get<Company>(_session.Save(TestDataGenerator.getCompany()));
            var inVal = TestDataGenerator.getOffer(company, material);
            //when
            _sut.Add(inVal);
            var outVal = _session.Get<Offer>(inVal.Id);
            //then
            Assert.AreEqual(inVal.Comments, outVal.Comments);
            Assert.AreEqual(inVal.Company, outVal.Company);
            Assert.AreEqual(inVal.Material, outVal.Material);
            Assert.AreEqual(inVal.Unit, outVal.Unit);
            Assert.AreEqual(inVal.LastModification, outVal.LastModification);
            Assert.AreEqual(inVal.UnitPrice, outVal.UnitPrice);
        }

        [Test]
        public void should_edit_offer()
        {
            //given
            const string newComments = "new comments";
            const string newUint = "new unit";
            const decimal newPrice = 12M;
            var newDate = DateTime.Now;
            var material = _session.Get<Material>(_session.Save(TestDataGenerator.GetMaterial()));
            var company = _session.Get<Company>(_session.Save(TestDataGenerator.getCompany()));
            var offer = _session.Get<Offer>(_session.Save(TestDataGenerator.getOffer(company, material)));
            var id = offer.Id;
            //when
            offer.Comments = newComments;
            offer.Unit = newUint;
            offer.UnitPrice = newPrice;
            offer.LastModification = newDate;
            _sut.Update(offer);
            var outVal = _session.Get<Offer>(offer.Id);
            //then
            Assert.AreEqual(newComments, outVal.Comments);
            Assert.AreEqual(newUint, outVal.Unit);
            Assert.AreEqual(newPrice, outVal.UnitPrice);
            Assert.AreEqual(newDate, outVal.LastModification);
            Assert.AreEqual(id, outVal.Id);
        }

        [Test]
        public void should_remove_offer()
        {
            //given
            var material = _session.Get<Material>(_session.Save(TestDataGenerator.GetMaterial()));
            var company = _session.Get<Company>(_session.Save(TestDataGenerator.getCompany()));
            var offer = _session.Get<Offer>(_session.Save(TestDataGenerator.getOffer(company, material)));
            //when
            _sut.Remove(offer);
            //then
            CollectionAssert.IsEmpty(_session.Query<Offer>().ToList());
        }

        [Test]
        public void should_return_list_with_two_elements()
        {
            //given
            var material = _session.Get<Material>(_session.Save(TestDataGenerator.GetMaterial()));
            var company = _session.Get<Company>(_session.Save(TestDataGenerator.getCompany()));
            _session.Save(TestDataGenerator.getOffer(company, material));
            _session.Save(TestDataGenerator.getOffer(company, material));
            //when & then
            Assert.AreEqual(2, _sut.GetAll().Count);
        }

        [Test]
        public void should_return_null_when_offer_does_not_exist()
        {
            //given & when & then
            Assert.IsNull(_sut.GetById(Guid.Empty));
        }

        [Test]
        public void should_return_offer_by_id()
        {
            //given
            var material = _session.Get<Material>(_session.Save(TestDataGenerator.GetMaterial()));
            var company = _session.Get<Company>(_session.Save(TestDataGenerator.getCompany()));
            var id = _session.Save(TestDataGenerator.getOffer(company, material)).As<Guid>();
            //when
            var outVal = _sut.GetById(id);
            //then
            Assert.NotNull(outVal);
            Assert.AreEqual(id, outVal.Id);
        }
    }
}