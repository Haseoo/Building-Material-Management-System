namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class CompanyContactData
    {
        public string Description { get; set; }
        public string Representative { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        protected bool Equals(CompanyContactData other)
        {
            return Description == other.Description &&
                   Representative == other.Representative &&
                   EmailAddress == other.EmailAddress &&
                   PhoneNumber == other.PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CompanyContactData) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Representative != null ? Representative.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmailAddress != null ? EmailAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}