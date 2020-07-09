namespace com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs
{
    public sealed class CompanyContactDataOperationDto
    {
        private CompanyContactDataOperationDto()
        {
        }

        public string Description { get; private set; }
        public string RepresentativeNameAndSurname { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }

        public static DtoBuilder Builder()
        {
            return new DtoBuilder();
        }

        public class DtoBuilder : IDtoBuilder<CompanyContactDataOperationDto>
        {
            private string _description;
            private string _representativeNameAndSurname;
            private string _emailAddress;
            private string _phoneNumber;

            public DtoBuilder Description(string description)
            {
                _description = description;
                return this;
            }

            public DtoBuilder RepresentativeNameAndSurname(string representativeNameAndSurname)
            {
                _representativeNameAndSurname = representativeNameAndSurname;
                return this;
            }

            public DtoBuilder EmailAddress(string emailAddress)
            {
                _emailAddress = emailAddress;
                return this;
            }

            public DtoBuilder PhoneNumber(string phoneNumber)
            {
                _phoneNumber = phoneNumber;
                return this;
            }

            public CompanyContactDataOperationDto Build()
            {
                return new CompanyContactDataOperationDto
                {
                    Description = _description,
                    RepresentativeNameAndSurname = _representativeNameAndSurname,
                    EmailAddress = _emailAddress,
                    PhoneNumber = _phoneNumber
                };
            }
        }
    }
}