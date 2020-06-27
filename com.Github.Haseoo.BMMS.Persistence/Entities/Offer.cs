using System;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class Offer : Entity
    {
        virtual public Company Company { get; set; }
        virtual public Material Material { get; set; }
        virtual public decimal UnitPrice { get; set; }
        virtual public string Unit { get; set; }
        virtual public string Comments { get; set; }
        virtual public DateTime LastModification { get; set; }
    }
}