using com.Github.Haseoo.BMMS.Data.Entities;
using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public class OrderPositionDto : EntityDto
    {
        private OrderPositionDto(Guid id, int quantity, OfferDto offer) : base(id)
        {
            Quantity = quantity;
            Offer = offer;
        }

        public int Quantity { get; }
        public OfferDto Offer { get; }

        public static OrderPositionDto From(OrderPosition orderPosition)
        {
            return new OrderPositionDto(orderPosition.Id,
                orderPosition.Quantity,
                OfferDto.From(orderPosition.Offer));
        }
    }
}