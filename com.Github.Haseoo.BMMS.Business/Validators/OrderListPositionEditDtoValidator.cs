using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class OrderListPositionEditDtoValidator : AbstractValidator<OrderListPositionOperationDto>
    {
        public OrderListPositionEditDtoValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero");
        }
    }
}