using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs
{
    public class OrderListUpdateDto
    {
        private OrderListUpdateDto()
        {
        }

        public string Name { get; private set; }
        public IList<OrderListPositionOperationDto> OrderPositions { get; private set; }

        public static DtoBuilder Builder()
        {
            return new DtoBuilder();
        }

        public class DtoBuilder : IDtoBuilder<OrderListUpdateDto>
        {
            private string _name;

            private readonly IList<OrderListPositionOperationDto> _orderPositions =
                new List<OrderListPositionOperationDto>();

            public DtoBuilder Name(string name)
            {
                _name = name;
                return this;
            }

            public DtoBuilder OrderPosition(OrderListPositionOperationDto orderPosition)
            {
                _orderPositions.Add(orderPosition);
                return this;
            }

            public OrderListUpdateDto Build()
            {
                return new OrderListUpdateDto()
                {
                    Name = _name,
                    OrderPositions = _orderPositions
                };
            }
        }
    }
}