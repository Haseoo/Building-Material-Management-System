using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class Company : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<CompanyContactData> ContactData { get; set; }
    }
}