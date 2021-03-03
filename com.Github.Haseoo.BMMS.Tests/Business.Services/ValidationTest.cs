using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Tests.Config;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.Tests.Business.Services
{
    [TestFixture]
    public class ValidationTest
    {
        private readonly ValidatorContext _sut = new ValidatorContext();

        [Test]
        public void should_pass_contact_data_operation_dto()
        {
            //given
            var inDto = TestDataGenerator.GetCompanyOperationDto().ContactData[0];
            //when & then
            Assert.IsTrue(_sut.CompanyContactDataValidator.Validate(inDto).IsValid);
        }

        [Test]
        public void should_pass_company_data_operation_dto_edit()
        {
            //given
            var inDto = TestDataGenerator.GetCompanyOperationDto();
            //when & then
            Assert.IsTrue(_sut.CompanyEditDtoValidator.Validate(inDto).IsValid);
        }

        [Test]
        public void should_pass_company_data_operation_dto_add()
        {
            //given
            var inDto = TestDataGenerator.GetCompanyOperationDto();
            //when & then
            Assert.IsTrue(_sut.CompanyAddDtoValidator.Validate(inDto).IsValid);
        }

        [Test]
        public void should_pass_material_data_operation_dto_edit()
        {
            //given
            var inDto = TestDataGenerator.GetMaterialOperationDto();
            //when & then
            Assert.IsTrue(_sut.MaterialEditDtoValidator.Validate(inDto).IsValid);
        }

        [Test]
        public void should_pass_material_data_operation_dto_add()
        {
            //given
            var inDto = TestDataGenerator.GetMaterialOperationDto();
            //when & then
            Assert.IsTrue(_sut.MaterialAddDtoValidator.Validate(inDto).IsValid);
        }

        [Test]
        public void should_pass_offer_data_operation_dto_edit()
        {
            //given
            var inDto = TestDataGenerator.GetOfferOperationDto(Guid.NewGuid(), Guid.NewGuid());
            //when & then
            Assert.IsTrue(_sut.OfferEditDtoValidator.Validate(inDto).IsValid);
        }

        [Test]
        public void should_pass_offer_data_operation_dto_add()
        {
            //given
            var inDto = TestDataGenerator.GetOfferOperationDto(Guid.NewGuid(), Guid.NewGuid());
            //when & then
            Assert.IsTrue(_sut.OfferAddDtoValidator.Validate(inDto).IsValid);
        }
    }
}
