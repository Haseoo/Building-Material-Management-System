namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class CompanyContactData : Entity
    {
        public virtual string Description { get; set; }
        public virtual string Representative { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}