using com.Github.Haseoo.BMMS.Data;
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
    public class MaterialRepositoryRepositoryTest : RepositoryTestSetupFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _sut = new MaterialRepository(new SessionWrapper(_session));
        }

        [TearDown]
        public override void TestTeardown()
        {
            base.TestTeardown();
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
            Assert.AreEqual(inVal.Name, outVal.Name);
            Assert.AreEqual(inVal.Specification, outVal.Specification);
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
            Assert.AreEqual(id, material.Id);
            Assert.AreEqual(newName, material.Name);
            Assert.AreEqual(newSpec, material.Specification);
        }

        [Test]
        public void should_return_list_with_two_elements()
        {
            //given
            _session.Save(TestDataGenerator.GetMaterial());
            _session.Save(TestDataGenerator.GetMaterial());
            //when & then
            Assert.AreEqual(2, _sut.GetAll().Count);
        }

        [Test]
        public void should_return_material_by_id()
        {
            //given
            var id = _session.Save(TestDataGenerator.GetMaterial()).As<Guid>();
            //when
            var outVal = _sut.GetById(id);
            //then
            Assert.AreEqual(id, outVal.Id);
        }

        [Test]
        public void should_return_null_when_material_does_not_exist()
        {
            //given & when & then
            Assert.IsNull(_sut.GetById(Guid.Empty));
        }
    }
}