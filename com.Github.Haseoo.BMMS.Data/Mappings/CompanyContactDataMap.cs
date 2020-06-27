using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class CompanyContactDataMap : EntityMap<CompanyContactData>
    {
        public CompanyContactDataMap()
        {
            Table("COMPANY_CONTACT_DATA");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Description);
            Map(x => x.Representative);
            Map(x => x.EmailAddress);
            Map(x => x.PhoneNumber);
        }
    }
}