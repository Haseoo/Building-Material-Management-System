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
    public class MaterialServiceTest
    {
        private Mock<IMaterialRepository> _repositoryMock;
        private MaterialService _sut;

        [SetUp]
        public void Setup()
        {
            _repositoryMock =  new Mock<IMaterialRepository>();
            _sut = new MaterialService(_repositoryMock.Object, MapperConf.Mapper);
        }

        [Test]
        public void should_get_by_id()
        {
            //given
            var id = Guid.NewGuid();
            var material = TestDataGenerator.GetMaterial();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(material);
            //when
            var outVal = _sut.GetById(id);
            //then
            _repositoryMock.Verify(e => e.GetById(id), Times.AtLeastOnce);
            Assert.AreEqual(material.Name, outVal.Name);
        }

        [Test]
        public void should_throw_not_found_exception()
        {
            //given
            _repositoryMock
                .Setup(e => e.GetById(It.IsAny<Guid>()))
                .Returns(null as Material);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.GetById(Guid.Empty));

        }

        [Test]
        public void should_return_list()
        {
            //given
            var mockList = new List<Material>()
            {
                TestDataGenerator.GetMaterial(),
                TestDataGenerator.GetMaterial()
            };
            _repositoryMock.Setup(e => e.GetAll()).Returns(mockList.AsQueryable);
            //when
            var outList = _sut.GetList();
            //then
            Assert.AreEqual(mockList.Count, outList.Count);
            _repositoryMock.Verify(e => e.GetAll(), Times.AtLeastOnce);
        }

        [Test]
        public void should_add_material()
        {
            //given
            var inDto = TestDataGenerator.GetMaterialOperationDto();
            var materialEntity = TestDataGenerator.GetMaterial();
            _repositoryMock
                .Setup(e => e.Add(It.IsAny<Material>()))
                .Returns(materialEntity);
            //when
            var outDto = _sut.Add(inDto);
            //then
            _repositoryMock
                .Verify(e => e.Add(It.Is<Material>(material => CheckInDto(inDto, material))),
                    Times.Once);
            Assert.IsTrue(CheckOutDto(outDto, materialEntity));
        }

        [Test]
        public void should_remove_material()
        {
            //given
            Guid id = Guid.NewGuid();
            var materialEntity = TestDataGenerator.GetMaterial();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(materialEntity);
            //when
            _sut.Delete(id);
            //then
            _repositoryMock.Verify(e => e.Remove(materialEntity), Times.Once);
        }

        [Test]
        public void should_throw_not_found_exception_when_removing_not_existent_material()
        {
            //given
            Guid id = Guid.NewGuid();
            var materialEntity = TestDataGenerator.GetMaterial();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(null as Material);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.Delete(id));
            _repositoryMock.Verify(e => e.Remove(materialEntity), Times.Never);
        }

        [Test]
        public void should_throw_not_found_exception_when_updating_not_existent_material()
        {
            //given
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(null as Material);
            //when & then
            Assert.Throws<NotFoundException>(() => _sut.Update(id, null));
            _repositoryMock.Verify(e => e.Update(It.IsAny<Material>()), Times.Never);
        }

        [Test]
        public void should_update_material()
        {
            //given
            Guid id = Guid.NewGuid();
            var existingEntity = TestDataGenerator.GetMaterial();
            var inDto = TestDataGenerator.GetMaterialOperationDto();
            _repositoryMock.Setup(e => e.GetById(id)).Returns(existingEntity);
            //when
            _sut.Update(id, inDto);
            //then
            _repositoryMock.Verify(e => e.GetById(id));
            _repositoryMock
                .Verify(e => e.Update(It.Is<Material>(material => CheckInDto(inDto, material))),
                    Times.AtLeastOnce);
        }

        private static bool CheckInDto(MaterialOperationDto operationDto, Material material)
        {
            return operationDto.Name.Equals(material.Name) &&
                   operationDto.Specification.Equals(material.Specification);
        }

        private static bool CheckOutDto(MaterialDto dto, Material entity)
        {
            return dto.Name.Equals(entity.Name) &&
                   dto.Specification.Equals(entity.Specification) &&
                   dto.Id.Equals(entity.Id);
        }
    }
}
