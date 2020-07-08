namespace com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs
{
    public sealed class MaterialOperationDto
    {
        private MaterialOperationDto()
        {
        }

        public string Name { get; private set; }
        public string Specification { get; private set; }

        public class DtoBulder
        {
            private string _name;
            private string _specification;

            public DtoBulder Name(string name)
            {
                _name = name;
                return this;
            }

            public DtoBulder Specification(string specification)
            {
                _specification = specification;
                return this;
            }

            public MaterialOperationDto Build()
            {
                var dto = new MaterialOperationDto
                {
                    Name = _name,
                    Specification = _specification
                };
                return dto;
            }
        }

        public static DtoBulder Builder()
        {
            return new DtoBulder();
        }
    }
}