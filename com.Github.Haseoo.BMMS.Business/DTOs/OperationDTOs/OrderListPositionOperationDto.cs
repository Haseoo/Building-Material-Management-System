using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs
{
    public class OrderListPositionOperationDto
    {
        private OrderListPositionOperationDto()
        {
        }

        public Guid OrderListId { get; private set; }
        public Guid OfferId { get; private set; }
        public int Quantity { get; private set; }

        public static DtoBuilder Builder()
        {
            return new DtoBuilder();
        }

        public class DtoBuilder : IDtoBuilder<OrderListPositionOperationDto>
        {
            private Guid _orderListId;
            private Guid _offerId;
            private int _quantity;

            public DtoBuilder OrderListId(Guid orderListId)
            {
                _orderListId = orderListId;
                return this;
            }

            public DtoBuilder OfferId(Guid offerId)
            {
                _offerId = offerId;
                return this;
            }

            public DtoBuilder Quantity(int quantity)
            {
                _quantity = quantity;
                return this;
            }

            public OrderListPositionOperationDto Build()
            {
                return new OrderListPositionOperationDto
                {
                    OfferId = _offerId,
                    OrderListId = _orderListId,
                    Quantity = _quantity
                };
            }
        }
    }
}