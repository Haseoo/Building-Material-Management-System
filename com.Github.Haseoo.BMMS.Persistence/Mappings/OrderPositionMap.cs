using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class OrderPositionMap : EntityMap<OrderPosition>
    {
        public OrderPositionMap()
        {
            Table("ORDER_POSITIONS");
            Map(x => x.Quantity,
                    "QUANTITY")
                .Not.Nullable();

            References(x => x.OrderList)
                .Column("ORDER_LIST_ID")
                .ForeignKey("POSITION_ORDER_FK")
                .Not.Nullable();

            References(x => x.Offer)
                .Column("MATERIAL_ID")
                .ForeignKey("POSITION_OFFER_FK")
                .Not.Nullable();

            CheckConstraint("QUANTITY > 0");
        }
    }
}