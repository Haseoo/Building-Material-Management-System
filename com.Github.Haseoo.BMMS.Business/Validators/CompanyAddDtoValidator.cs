using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class CompanyAddDtoValidator : AbstractValidator<CompanyOperationDto>
    {
        public CompanyAddDtoValidator(CompanyContactDataValidator companyContactDataValidator)
        {
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleFor(x => x.Voivodeship)
                .NotEmpty()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleForEach(x => x.ContactData)
                .SetValidator(companyContactDataValidator)
                .When(x => x.ContactData != null);
        }
    }
}