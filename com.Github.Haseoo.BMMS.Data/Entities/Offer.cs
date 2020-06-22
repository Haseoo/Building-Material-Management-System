using System;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class Offer : Entity
    {
        public Company Company { get; set; }
        public Material Material { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
        public string Comments { get; set; }
        public DateTime LastModification { get; set; }
    }
}