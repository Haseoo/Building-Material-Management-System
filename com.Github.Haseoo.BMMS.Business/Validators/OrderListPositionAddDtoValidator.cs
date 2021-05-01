using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;
using System;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class OrderListPositionAddDtoValidator : AbstractValidator<OrderListPositionOperationDto>
    {
        public OrderListPositionAddDtoValidator()
        {
            RuleFor(x => x.OfferId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.OrderPosition));
            RuleFor(x => x.OrderListId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.OrderPosition));
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero");
        }
    }
}