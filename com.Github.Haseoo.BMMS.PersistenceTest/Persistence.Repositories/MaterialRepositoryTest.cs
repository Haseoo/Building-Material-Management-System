using System;
using System.Linq;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using com.Github.Haseoo.BMMS.PersistenceTest.Config;
using NHibernate.Linq;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.PersistenceTest.Persistence.Repositories
{
    [TestFixture]
    public class MaterialRepositoryTest : TestSetupFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _sut = new MaterialRepository(_session);
        }

        private MaterialRepository _sut;

        [Test]
        public void should_add_material()
        {
            //given
            var inVal = TestDataGenerator.GetMaterial();
            //when
            _sut.Add(inVal);
            var outVal = _session.Get<Material>(inVal.Id);

            //then
            Assert.NotNull(inVal.Id);
            Assert.Contains(inVal, _session.Query<Material>().ToList());
            Assert.AreEqual(outVal.Name, inVal.Name);
            Assert.AreEqual(outVal.Specification, inVal.Specification);
        }

        [Test]
        public void should_delete_material()
        {
            //given
            var material = _session.Get<Material>(_session.Save(TestDataGenerator.GetMaterial()));
            //when
            _sut.Remove(material);
            //then
            CollectionAssert.DoesNotContain(_session.Query<Material>().ToList(), material);
        }

        [Test]
        public void should_edit_material()
        {
            //given
            const string newName = "new name";
            const string newSpec = "new spec";
            var material = _session.Get<Material>(_session.Save(TestDataGenerator.GetMaterial()));
            //when
            var id = material.Id;
            material.Name = newName;
            material.Specification = newSpec;
            _sut.Update(material);
            //then
            Assert.AreEqual(material.Id, id);
            Assert.AreEqual(material.Name, newName);
            Assert.AreEqual(material.Specification, newSpec);
        }

        [Test]
        public void should_return_list_with_two_elements()
        {
            //given
            _session.Save(TestDataGenerator.GetMaterial());
            _session.Save(TestDataGenerator.GetMaterial());
            //when & then
            Assert.AreEqual(_sut.GetAll().Count, 2);
        }

        [Test]
        public void should_return_material_by_id()
        {
            //given
            var id = _session.Save(TestDataGenerator.GetMaterial()).As<Guid>();
            //when
            var outVal = _sut.GetById(id);
            //then
            Assert.AreEqual(outVal.Id, id);
        }
    }
}