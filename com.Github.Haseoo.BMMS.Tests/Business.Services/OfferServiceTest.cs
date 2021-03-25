using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using com.Github.Haseoo.BMMS.Tests.Config;
using com.Github.Haseoo.BMMS.WinForms.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Tests.Business.Services
{
    [TestFixture]
    public class OfferServiceTest
    {
        private Mock<ICompanyRepository> _companyRepositoryMock;
        private Mock<IMaterialRepository> _materialRepositoryMock;
        private Mock<IOfferRepository> _offerRepositoryMock;
        private OfferService _sut;

        [SetUp]
        public void Setup()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _materialRepositoryMock = new Mock<IMaterialRepository>();
            _offerRepositoryMock = new Mock<IOfferRepository>();
            _sut = new OfferService(_offerRepositoryMock.Object,
                _companyRepositoryMock.Object,
                _materialRepositoryMock.Object,
                MapperConf.Mapper);
        }

        [Test]
        public void should_get_offer_by_id()
        {
            //given
            var id = Guid.NewGuid();
            var offer = TestDataGenerator.GetOffer(TestDataGenerator.GetCompany(), TestDataGenerator.GetMaterial());
            _offerRepositoryMock.Setup(e => e.GetById(id)).Returns(offer);
            //when
            var outDto = _sut.GetById(id);
            //then
            _offerRepositoryMock.Verify(e => e.GetById(id), Times.AtLeastOnce);
            Assert.IsTrue(CheckOutDto(outDto, offer));
        }

        [Test]
        public void should_throw_not_found_exception()
        {
            //given
            _offerRepositoryMock
                .Setup(e => e.GetById(It.IsAny<Guid>()))
                .Returns(null as Offer);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.GetById(Guid.Empty));
        }

        [Test]
        public void should_return_offer_for_company_list()
        {
            var company = TestDataGenerator.GetCompany();
            company.Id = Guid.NewGuid();
            var material = TestDataGenerator.GetMaterial();
            material.Id = Guid.NewGuid();
            //given
            var mockList = new List<Offer>()
            {
                TestDataGenerator.GetOffer(company, material),
                TestDataGenerator.GetOffer(TestDataGenerator.GetCompany(), material),
                TestDataGenerator.GetOffer(company, material),
                TestDataGenerator.GetOffer(TestDataGenerator.GetCompany(), TestDataGenerator.GetMaterial())
            };
            _offerRepositoryMock.Setup(e => e.GetAll()).Returns(mockList.AsQueryable);
            //when
            var outList = _sut.GetCompanyOffers(company.Id);
            //then
            Assert.AreEqual(2, outList.Count);
            _offerRepositoryMock.Verify(e => e.GetAll(), Times.AtLeastOnce);
        }

        [Test]
        public void should_return_offer_for_material_list()
        {
            var company = TestDataGenerator.GetCompany();
            company.Id = Guid.NewGuid();
            var material = TestDataGenerator.GetMaterial();
            material.Id = Guid.NewGuid();
            //given
            var mockList = new List<Offer>()
            {
                TestDataGenerator.GetOffer(company, material),
                TestDataGenerator.GetOffer(company, TestDataGenerator.GetMaterial()),
                TestDataGenerator.GetOffer(TestDataGenerator.GetCompany(), TestDataGenerator.GetMaterial()),
                TestDataGenerator.GetOffer(company, material),
            };
            _offerRepositoryMock.Setup(e => e.GetAll()).Returns(mockList.AsQueryable);
            //when
            var outList = _sut.GetMaterialOffers(material.Id);
            //then
            Assert.AreEqual(2, outList.Count);
            _offerRepositoryMock.Verify(e => e.GetAll(), Times.AtLeastOnce);
        }

        [Test]
        public void should_add_offer()
        {
            //given
            PrepareAddOrUpdateEntities(out var id,
                out var companyEntity,
                out var materialEntity,
                out var offerEntity,
                out var inDto);
            _offerRepositoryMock
                .Setup(e => e.Add(It.IsAny<Offer>()))
                .Returns(offerEntity);
            _materialRepositoryMock.Setup(e => e.GetById(materialEntity.Id))
                .Returns(materialEntity);
            _companyRepositoryMock.Setup(e => e.GetById(companyEntity.Id))
                .Returns(companyEntity);
            //when
            var outDto = _sut.Add(inDto);
            //then
            _offerRepositoryMock
                .Verify(e => e.Add(It.Is<Offer>(c => CheckInDto(inDto, c))),
                    Times.Once);
            _materialRepositoryMock.Verify(e => e.GetById(inDto.MaterialId), Times.AtLeastOnce);
            _companyRepositoryMock.Verify(e => e.GetById(inDto.CompanyId), Times.AtLeastOnce);
            Assert.IsTrue(CheckOutDto(outDto, offerEntity));
        }

        [Test]
        public void should_remove_offer()
        {
            //given
            Guid id = Guid.NewGuid();
            var offer = TestDataGenerator.GetOffer(TestDataGenerator.GetCompany(), TestDataGenerator.GetMaterial());
            _offerRepositoryMock.Setup(e => e.GetById(id)).Returns(offer);
            //when
            _sut.Delete(id);
            //then
            _offerRepositoryMock.Verify(e => e.Remove(offer), Times.Once);
        }

        [Test]
        public void should_throw_not_found_exception_when_removing_not_existent_offer()
        {
            //given
            Guid id = Guid.NewGuid();
            var offer = TestDataGenerator.GetOffer(TestDataGenerator.GetCompany(), TestDataGenerator.GetMaterial());
            _offerRepositoryMock.Setup(e => e.GetById(id)).Returns(null as Offer);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.Delete(id));
            _offerRepositoryMock.Verify(e => e.Remove(offer), Times.Never);
        }

        [Test]
        public void should_throw_not_found_exception_when_updating_not_existent_offer()
        {
            //given
            Guid id = Guid.NewGuid();
            _offerRepositoryMock.Setup(e => e.GetById(id)).Returns(null as Offer);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.Update(id, TestDataGenerator.GetOfferOperationDto()));
            _offerRepositoryMock.Verify(e => e.Update(It.IsAny<Offer>()), Times.Never);
        }

        [Test]
        public void should_update_offer()
        {
            //given
            var id = Guid.NewGuid();
            var existingEntity =
                TestDataGenerator.GetOffer(TestDataGenerator.GetCompany(), TestDataGenerator.GetMaterial());
            var inDto = TestDataGenerator.GetOfferOperationDto(existingEntity.Company.Id, existingEntity.Material.Id);
            _offerRepositoryMock.Setup(e => e.GetById(id)).Returns(existingEntity);
            _offerRepositoryMock
                .Setup(e => e.Update(It.IsAny<Offer>()))
                .Returns(existingEntity);
            //when
            _sut.Update(id, inDto);
            //then
            _offerRepositoryMock.Verify(e => e.GetById(id));
            _offerRepositoryMock
                .Verify(e => e.Update(It.Is<Offer>(c => CheckInDto(inDto, c))),
                    Times.AtLeastOnce);
            _materialRepositoryMock.Verify(e => e.GetById(inDto.MaterialId), Times.Never);
            _companyRepositoryMock.Verify(e => e.GetById(inDto.CompanyId), Times.Never);
        }

        [Test]
        public void should_update_offer_with_new_company_and_material()
        {
            //given
            PrepareAddOrUpdateEntities(out var id,
                out var companyEntity,
                out var materialEntity,
                out var existingEntity);

            var inDto = TestDataGenerator.GetOfferOperationDto(Guid.NewGuid(), Guid.NewGuid());

            _materialRepositoryMock.Setup(e => e.GetById(inDto.MaterialId))
                .Returns(materialEntity);
            _companyRepositoryMock.Setup(e => e.GetById(inDto.CompanyId))
                .Returns(companyEntity);

            _offerRepositoryMock.Setup(e => e.GetById(id)).Returns(existingEntity);
            _offerRepositoryMock
                .Setup(e => e.Update(It.IsAny<Offer>()))
                .Returns(existingEntity);
            //when
            _sut.Update(id, inDto);
            //then
            _offerRepositoryMock.Verify(e => e.GetById(id));
            _offerRepositoryMock
                .Verify(e => e.Update(It.Is<Offer>(c => CheckInDto(inDto, c))),
                    Times.AtLeastOnce);
            _materialRepositoryMock.Verify(e => e.GetById(inDto.MaterialId), Times.AtLeastOnce);
            _companyRepositoryMock.Verify(e => e.GetById(inDto.CompanyId), Times.AtLeastOnce);
        }

        private static void PrepareAddOrUpdateEntities(out Guid id, out Company companyEntity, out Material materialEntity,
            out Offer existingEntity)
        {
            id = Guid.NewGuid();
            companyEntity = TestDataGenerator.GetCompany();
            companyEntity.Id = Guid.NewGuid();
            materialEntity = TestDataGenerator.GetMaterial();
            materialEntity.Id = Guid.NewGuid();
            existingEntity = TestDataGenerator.GetOffer(companyEntity, materialEntity);
        }

        private static void PrepareAddOrUpdateEntities(out Guid id, out Company companyEntity, out Material materialEntity,
            out Offer existingEntity, out OfferOperationDto inDto)
        {
            PrepareAddOrUpdateEntities(out id, out companyEntity, out materialEntity, out existingEntity);
            inDto = TestDataGenerator.GetOfferOperationDto(companyEntity.Id, materialEntity.Id);
        }

        private static bool CheckInDto(OfferOperationDto operationDto, Offer entity)
        {
            return operationDto.Comments.Equals(entity.Comments) &&
                   operationDto.Unit.Equals(entity.Unit) &&
                   operationDto.UnitPrice.Equals(entity.UnitPrice);
        }

        private static bool CheckOutDto(OfferDto dto, Offer entity)
        {
            return dto.Comments.Equals(entity.Comments) &&
                   dto.CompanyName.Equals(entity.Company.Name) &&
                   dto.LastModification.Equals(entity.LastModification.ToString("yyyy MMM dd HH:mm:ss")) &&
                   dto.Unit.Equals(entity.Unit) &&
                   dto.UnitPrice.Equals(entity.UnitPrice);
        }
    }
}