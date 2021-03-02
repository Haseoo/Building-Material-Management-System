using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class CompanyEditDtoValidator : AbstractValidator<CompanyOperationDto>
    {
        public CompanyEditDtoValidator(CompanyContactDataValidator companyContactDataValidator)
        {
            RuleForEach(x => x.ContactData)
                .SetValidator(companyContactDataValidator)
                .When(x => x.ContactData != null);
        }
    }
}