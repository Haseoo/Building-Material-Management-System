using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class OrderListMap : EntityMap<OrderList>
    {
        public OrderListMap()
        {
            Table("ORDER_LISTS");
            Map(x => x.LastModification,
                "LAST_MODIFICATION_DATE");
            Map(x => x.Name,
                    "NAME")
                .CustomSqlType("text")
                .Not.Nullable();
            HasMany(x => x.OrderPositions)
                .KeyColumn("ORDER_LIST_ID")
                .ForeignKeyConstraintName("ORDER_LIST_POSITION_FK")
                .Not.KeyNullable()
                .Not.KeyUpdate()
                .Not.Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}