using com.Github.Haseoo.BMMS.Data.Entities;
using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public class OrderListShortDto : EntityDto
    {
        protected OrderListShortDto(Guid id,
            string name,
            DateTime lastModification) : base(id)
        {
            Name = name;
            LastModification = lastModification.ToString("yyyy MMM dd HH:mm:ss");
        }

        public string Name { get; }
        public string LastModification { get; }

        public static OrderListShortDto From(OrderList orderList)
        {
            return new OrderListShortDto(orderList.Id,
                orderList.Name,
                orderList.LastModification);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}