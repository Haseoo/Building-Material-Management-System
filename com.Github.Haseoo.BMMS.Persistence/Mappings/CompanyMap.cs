using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class CompanyMap : EntityMap<Company>
    {
        public CompanyMap()
        {
            Table("COMPANIES");
            Map(x => x.Name,
                    "NAME")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.Address,
                    "ADDRESS")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.City,
                    "CITY")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.Voivodeship,
                    "VOIVODESHIP")
                .CustomSqlType("text")
                .Not.Nullable();
            HasMany(x => x.Offers)
                .Cascade.AllDeleteOrphan()
                .Fetch.Join()
                .Inverse().KeyColumn("COMPANY_ID");
            
            HasMany(x => x.ContactData)
                .KeyColumn("COMPANY_ID")
                .Not.KeyNullable()
                .Not.KeyUpdate()
                .Not.Inverse()
                .Cascade.All();
        }
    }
}