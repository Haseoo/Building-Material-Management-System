using System.Collections;
using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<CompanyContactData> ContactData { get; set; }
    }
}