using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class CompanyEditDtoValidator : AbstractValidator<CompanyOperationDto>
    {
        public CompanyEditDtoValidator(CompanyContactDataValidator companyContactDataValidator)
        {
            RuleFor(x => x.Address)
                .NotEmpty()
                .When(x => x.Address != null)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleFor(x => x.City)
                .NotEmpty()
                .When(x => x.City != null)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleFor(x => x.Name)
                .NotEmpty()
                .When(x => x.Name != null)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleFor(x => x.Voivodeship)
                .NotEmpty()
                .When(x => x.Voivodeship != null)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Company));
            RuleForEach(x => x.ContactData)
                .SetValidator(companyContactDataValidator)
                .When(x => x.ContactData != null);
        }
    }
}