using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs
{
    public sealed class CompanyOperationDto
    {
        private CompanyOperationDto()
        {
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Voivodeship { get; private set; }
        public string City { get; private set; }
        public IList<CompanyContactDataOperationDto> ContactData { get; private set; }

        public static DtoBuilder Builder()
        {
            return new DtoBuilder();
        }

        public class DtoBuilder : IDtoBuilder<CompanyOperationDto>
        {
            private string _name;
            private string _address;
            private string _voivodeship;
            private string _city;
            private readonly IList<CompanyContactDataOperationDto> _contactData = new List<CompanyContactDataOperationDto>();

            public DtoBuilder Name(string name)
            {
                _name = name;
                return this;
            }

            public DtoBuilder Address(string address)
            {
                _address = address;
                return this;
            }

            public DtoBuilder Voivodeship(string voivodeship)
            {
                _voivodeship = voivodeship;
                return this;
            }

            public DtoBuilder City(string city)
            {
                _city = city;
                return this;
            }

            public DtoBuilder ContactData(CompanyContactDataOperationDto contactData)
            {
                _contactData.Add(contactData);
                return this;
            }

            public CompanyOperationDto Build()
            {
                return new CompanyOperationDto
                {
                    Name = _name,
                    Address = _address,
                    Voivodeship = _voivodeship,
                    City = _city,
                    ContactData = new List<CompanyContactDataOperationDto>(_contactData)
                };
            }
        }
    }
}