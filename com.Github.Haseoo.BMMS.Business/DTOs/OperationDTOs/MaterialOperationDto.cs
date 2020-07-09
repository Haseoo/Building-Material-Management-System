namespace com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs
{
    public sealed class MaterialOperationDto
    {
        private MaterialOperationDto()
        {
        }

        public string Name { get; private set; }
        public string Specification { get; private set; }

        public class DtoBuilder : IDtoBuilder<MaterialOperationDto>
        {
            private string _name;
            private string _specification;

            public DtoBuilder Name(string name)
            {
                _name = name;
                return this;
            }

            public DtoBuilder Specification(string specification)
            {
                _specification = specification;
                return this;
            }

            public MaterialOperationDto Build()
            {
                return new MaterialOperationDto
                {
                    Name = _name,
                    Specification = _specification
                };
            }
        }

        public static DtoBuilder Builder()
        {
            return new DtoBuilder();
        }
    }
}