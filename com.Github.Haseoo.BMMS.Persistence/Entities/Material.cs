using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class Material : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Specification { get; set; }
        
        public virtual IList<Offer> Offers { get; set; }
    }
}