using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class CompanyContactDataMap : EntityMap<CompanyContactData>
    {
        public CompanyContactDataMap()
        {
            Table("COMPANY_CONTACT_DATA");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Description,
                    "DESCRIPTION")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.RepresentativeNameAndSurname,
                    "REPRESENTATIVE_NAME_AND_SURNAME")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.EmailAddress,
                    "EMAIL_ADDRESS")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.PhoneNumber,
                    "PHONE_NUMBER")
                .CustomSqlType("text")
                .Not.Nullable();
        }
    }
}