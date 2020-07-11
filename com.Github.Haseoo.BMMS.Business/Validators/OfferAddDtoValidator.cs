using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class OfferAddDtoValidator : AbstractValidator<OfferOperationDto>
    {
        public OfferAddDtoValidator()
        {
            RuleFor(x => x.Unit)
                .NotEmpty()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Offer));
            RuleFor(x => x.CompanyId)
                .NotNull()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Offer));
            RuleFor(x => x.MaterialId)
                .NotNull()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Offer));
            RuleFor(x => x.UnitPrice)
                .NotNull()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Offer));
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0M)
                .WithMessage("Price must be greater than zero");
        }
    }
}
