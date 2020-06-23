using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.Data.UnitTests.Data.Repositories
{
    [TestFixture]
    public class OfferRepositoryTest
    {
        [SetUp]
        public void Init()
        {
            _testStorage = new Dictionary<Guid, Offer>();
            _sut = new OfferRepository(_testStorage);
        }

        private IOfferRepository _sut;
        private Dictionary<Guid, Offer> _testStorage;

        private static Offer GetTestOffer()
        {
            return new Offer
            {
                Comments = "Tets",
                Company = CompanyRepositoryTest.GetTestCompany(),
                Id = Guid.NewGuid(),
                LastModification = DateTime.Now,
                Material = MaterialRepositoryTest.GetTestMaterial(),
                Unit = "Ts",
                UnitPrice = 31.21M
            };
        }

        [Test]
        public void should_add_offer()
        {
            //given
            var offer = GetTestOffer();
            //when
            _sut.Add(offer);
            //then
            var outVal = _testStorage[offer.Id];
            Assert.NotNull(outVal);
            Assert.AreEqual(1, _testStorage.Keys.Count);
            Assert.AreEqual(offer.Id, outVal.Id);
            Assert.AreEqual(offer.Comments, outVal.Comments);
            Assert.AreEqual(offer.Company.Id, outVal.Company.Id);
            Assert.AreEqual(offer.Material.Id, outVal.Material.Id);
            Assert.AreEqual(offer.Unit, outVal.Unit);
            Assert.AreEqual(offer.LastModification, outVal.LastModification);
            Assert.AreEqual(offer.UnitPrice, outVal.UnitPrice);
        }

        [Test]
        public void should_remove_offer()
        {
            //given
            var offer = GetTestOffer();
            _testStorage.Add(offer.Id, offer);
            //when
            _sut.Remove(offer.Id);
            //then
            Assert.IsFalse(_testStorage.ContainsKey(offer.Id));
        }

        [Test]
        public void should_return_list_with_two_elements()
        {
            //given
            var offer = GetTestOffer();
            _testStorage.Add(offer.Id, offer);
            offer = GetTestOffer();
            offer.Id = Guid.NewGuid();
            _testStorage.Add(offer.Id, offer);
            //when
            var outList = _sut.GetAll();
            //then
            Assert.AreEqual(2, outList.Count);
        }

        [Test]
        public void should_return_null_when_offer_with_id_not_exist()
        {
            //given & when & then
            Assert.IsNull(_sut.GetById(Guid.NewGuid()));
        }

        [Test]
        public void should_return_offer_with_given_id()
        {
            //given
            var offer = GetTestOffer();
            _testStorage.Add(offer.Id, offer);
            //when
            var outVal = _sut.GetById(offer.Id);
            //then
            Assert.IsNotNull(outVal);
            Assert.AreEqual(offer.Id, outVal.Id);
        }
    }
}