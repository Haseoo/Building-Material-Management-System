using com.Github.Haseoo.BMMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public class OrderListFullDto : OrderListShortDto
    {
        protected OrderListFullDto(Guid id,
            string name,
            DateTime lastModification,
            IList<OrderPositionDto> orderPositions)
            : base(id, name, lastModification)
        {
            OrderPositions = orderPositions;
        }

        public IList<OrderPositionDto> OrderPositions { get; }

        public new static OrderListFullDto From(OrderList orderList)
        {
            return new OrderListFullDto(orderList.Id,
                orderList.Name,
                orderList.LastModification,
                orderList.OrderPositions
                    .Select(OrderPositionDto.From)
                    .ToList());
        }
    }
}