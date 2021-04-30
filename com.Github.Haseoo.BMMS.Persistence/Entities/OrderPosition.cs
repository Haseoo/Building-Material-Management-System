namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class OrderPosition : Entity
    {
        public virtual int Quantity { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual OrderList OrderList { get; set; }
    }
}
