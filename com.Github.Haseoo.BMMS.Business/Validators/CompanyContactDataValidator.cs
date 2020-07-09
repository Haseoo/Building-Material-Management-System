using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Extensions;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class CompanyContactDataValidator : AbstractValidator<CompanyContactDataOperationDto>
    {
        public CompanyContactDataValidator()
        {
            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .When(x => x.EmailAddress != null)
                .WithMessage($"{ValidatedEntities.CompanyContactData.GetDescription()}email address {{PropertyValue}} is not valid");
            RuleFor(x => x.PhoneNumber)
                .Matches("^[0-9]*$")
                .WithMessage($"{ValidatedEntities.CompanyContactData.GetDescription()} phone number can only contain digits");
        }
    }
}