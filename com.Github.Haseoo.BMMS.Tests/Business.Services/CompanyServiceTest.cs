using System;
using System.Collections.Generic;
using System.Linq;
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

namespace com.Github.Haseoo.BMMS.Tests.Business.Services
{
    [TestFixture]
    public class CompanyServiceTest
    {
        private Mock<ICompanyRepository> _repositoryMock;
        private CompanyService _sut;

        [SetUp]
        public void Setup()
        {
            _repositoryMock =  new Mock<ICompanyRepository>();
            _sut = new CompanyService(_repositoryMock.Object, MapperConf.Mapper);
        }

        [Test]
        public void should_get_company_by_id()
        {
            //given
            var id = Guid.NewGuid();
            var company = TestDataGenerator.GetCompany();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(company);
            //when
            var outDto = _sut.GetById(id);
            //then
            _repositoryMock.Verify(e => e.GetById(id), Times.AtLeastOnce);
            Assert.IsTrue(CheckOutDto(outDto, company));
        }

        [Test]
        public void should_throw_not_found_exception()
        {
            //given
            _repositoryMock
                .Setup(e => e.GetById(It.IsAny<Guid>()))
                .Returns(null as Company);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.GetById(Guid.Empty));

        }

        [Test]
        public void should_return_company_list()
        {
            //given
            var mockList = new List<Company>()
            {
                TestDataGenerator.GetCompany(),
                TestDataGenerator.GetCompany()
            };
            _repositoryMock.Setup(e => e.GetAll()).Returns(mockList.AsQueryable);
            //when
            var outList = _sut.GetList();
            //then
            Assert.AreEqual(mockList.Count, outList.Count);
            _repositoryMock.Verify(e => e.GetAll(), Times.AtLeastOnce);
        }

        [Test]
        public void should_add_company()
        {
            //given
            var inDto = TestDataGenerator.GetCompanyOperationDto();
            var companyEntity = TestDataGenerator.GetCompany();
            _repositoryMock
                .Setup(e => e.Add(It.IsAny<Company>()))
                .Returns(companyEntity);
            //when
            var outDto = _sut.Add(inDto);
            //then
            _repositoryMock
                .Verify(e => e.Add(It.Is<Company>(c => CheckInDto(inDto, c))),
                    Times.Once);
            Assert.IsTrue(CheckOutDto(outDto, companyEntity));
        }

        [Test]
        public void should_remove_company()
        {
            //given
            Guid id = Guid.NewGuid();
            var companyEntity = TestDataGenerator.GetCompany();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(companyEntity);
            //when
            _sut.Delete(id);
            //then
            _repositoryMock.Verify(e => e.Remove(companyEntity), Times.Once);
        }

        [Test]
        public void should_throw_not_found_exception_when_removing_not_existent_company()
        {
            //given
            Guid id = Guid.NewGuid();
            var companyEntity = TestDataGenerator.GetCompany();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(null as Company);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.Delete(id));
            _repositoryMock.Verify(e => e.Remove(companyEntity), Times.Never);
        }

        [Test]
        public void should_throw_not_found_exception_when_updating_not_existent_company()
        {
            //given
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(null as Company);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.Update(id, TestDataGenerator.GetCompanyOperationDto()));
            _repositoryMock.Verify(e => e.Update(It.IsAny<Company>()), Times.Never);
        }

        [Test]
        public void should_update_company()
        {
            //given
            Guid id = Guid.NewGuid();
            var existingEntity = TestDataGenerator.GetCompany();
            var inDto = TestDataGenerator.GetCompanyOperationDto();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(existingEntity);
            _repositoryMock.Setup(e => e.Update(It.IsAny<Company>())).Returns(existingEntity);
            //when
            _sut.Update(id, inDto);
            //then
            _repositoryMock.Verify(e => e.GetById(id));
            _repositoryMock
                .Verify(e => e.Update(It.Is<Company>(c => CheckInDto(inDto, c))),
                    Times.AtLeastOnce);
        }

        [Test]
        public void should_return_companies_with_name_that_contains_substring()
        {
            //given
            var mockList = new List<Company>()
            {
                TestDataGenerator.GetCompany(),
                TestDataGenerator.GetCompany(),
                TestDataGenerator.GetCompany(),
                TestDataGenerator.GetCompany()
            };
            mockList[2].Name = "Test2";
            mockList[3].Name = "CompletelyDifferentName";
            _repositoryMock.Setup(e => e.GetAll()).Returns(mockList.AsQueryable);
            const string subString = "Test";
            //when
            var outList = _sut.SearchByName(subString);
            //then
            Assert.AreEqual(3, outList.Count);
            Assert.IsTrue(outList.All(e => e.Name.Contains(subString)));
        }

        private static bool CheckInDto(CompanyOperationDto operationDto, Company entity)
        {
            var cDataDto = operationDto.ContactData[0];
            var cDataEntity = entity.ContactData[0];
            return operationDto.Name.Equals(entity.Name) &&
                   operationDto.Address.Equals(entity.Address) &&
                   operationDto.City.Equals(entity.City) &&
                   operationDto.Voivodeship.Equals(entity.Voivodeship) &&
                   cDataDto.RepresentativeNameAndSurname.Equals(cDataEntity.RepresentativeNameAndSurname) &&
                   cDataDto.EmailAddress.Equals(cDataEntity.EmailAddress) &&
                   cDataDto.PhoneNumber.Equals(cDataEntity.PhoneNumber) &&
                   cDataEntity.Description.Equals(cDataDto.Description);

        }

        private static bool CheckOutDto(CompanyDto dto, Company entity)
        {
            var cDataDto = dto.ContactData[0];
            var cDataEntity = entity.ContactData[0];
            return dto.Name.Equals(entity.Name) &&
                   dto.Address.Equals(entity.Address) &&
                   dto.City.Equals(entity.City) &&
                   dto.Voivodeship.Equals(entity.Voivodeship) &&
                   cDataDto.RepresentativeNameAndSurname.Equals(cDataEntity.RepresentativeNameAndSurname) &&
                   cDataDto.EmailAddress.Equals(cDataEntity.EmailAddress) &&
                   cDataDto.PhoneNumber.Equals(cDataEntity.PhoneNumber) &&
                   cDataEntity.Description.Equals(cDataDto.Description);
        }
    }
}
