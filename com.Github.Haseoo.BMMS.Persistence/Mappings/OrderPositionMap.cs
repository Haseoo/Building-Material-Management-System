using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class OrderPositionMap : EntityMap<OrderPosition>
    {
        public OrderPositionMap()
        {
            Table("ORDER_POSITIONS");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Quantity,
                    "QUANTITY")
                .Not.Nullable();

            References(x => x.Offer)
                .Column("OFFER_ID")
                .ForeignKey("POSITION_OFFER_FK")
                .Not.Nullable();

            CheckConstraint("QUANTITY > 0");
        }
    }
}