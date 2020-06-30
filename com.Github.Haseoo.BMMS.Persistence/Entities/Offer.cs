using System;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class Offer : Entity
    {
        public virtual Company Company { get; set; }
        public virtual Material Material { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual string Unit { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime LastModification { get; set; }
    }
}