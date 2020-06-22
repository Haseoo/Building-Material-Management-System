using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.Data.UnitTests.Repositories
{
    [TestFixture]
    public class MaterialRepositoryTest
    {
        private MaterialRepository _sut;
        private Dictionary<Guid, Material> _testStorage;

        [SetUp]
        public void Init()
        {
            _testStorage = new Dictionary<Guid, Material>();
            _sut = new MaterialRepository(_testStorage);
        }
        
        [Test]
        public void should_add_material()
        {
            //given
            var material = GetTestMaterial();
            //when
            _sut.Add(material);
            //then
            var outVal = _testStorage[material.Id];
            Assert.NotNull(outVal);
            Assert.AreEqual(1, _testStorage.Keys.Count);
            Assert.AreEqual(material.Id, outVal.Id);
            Assert.AreEqual(material.Name, outVal.Name);
            Assert.AreEqual(material.Specification, outVal.Specification);
        }

        [Test]
        public void should_remove_material()
        {
            //given
            var material = GetTestMaterial();
            _testStorage.Add(material.Id, material);
            //when
            _sut.Remove(material.Id);
            //then
            Assert.IsFalse(_testStorage.ContainsKey(material.Id));
        }

        [Test]
        public void should_return_list_with_two_elements()
        {
            //given
            var material = GetTestMaterial();
            _testStorage.Add(material.Id, material);
            material.Id = Guid.NewGuid();
            _testStorage.Add(material.Id, material);
            //when
            var outList = _sut.GetAll();
            //then
            Assert.AreEqual(2, outList.Count);
        }
        
        [Test]
        public void should_return_material_with_given_id() {
            //given
            var material = GetTestMaterial();
            _testStorage.Add(material.Id, material);
            //when
            var outVal = _sut.GetById(material.Id);
            //then
            Assert.IsNotNull(outVal);
            Assert.AreEqual(material.Id, outVal.Id);
        }

        [Test]
        public void should_return_null_when_material_with_id_not_exist()
        {
            //given & when & then
            Assert.IsNull(_sut.GetById(Guid.NewGuid()));
        }

        private static Material GetTestMaterial()
        {
            return new Material() {Id = Guid.NewGuid(),
                Name = "TestName",
                Specification = "TestSpec"};
        }
    }
}