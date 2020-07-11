using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs
{
    public sealed class OfferOperationDto
    {
        private OfferOperationDto()
        {
        }

        public Guid CompanyId { get; private set; }
        public Guid MaterialId { get; private set; }
        public decimal? UnitPrice { get; private set; }
        public string Unit { get; private set; }
        public string Comments { get; private set; }

        public static DtoBuilder Builder()
        {
            return new DtoBuilder();
        }

        public class DtoBuilder : IDtoBuilder<OfferOperationDto>
        {
            private Guid _companyId;
            private Guid _materialId;
            private decimal _unitPrice;
            private string _unit;
            private string _comments;

            public DtoBuilder CompanyId(Guid companyId)
            {
                _companyId = companyId;
                return this;
            }

            public DtoBuilder MaterialId(Guid materialId)
            {
                _materialId = materialId;
                return this;
            }

            public DtoBuilder UnitPrice(decimal unitPrice)
            {
                _unitPrice = unitPrice;
                return this;
            }

            public DtoBuilder Unit(string unit)
            {
                _unit = unit;
                return this;
            }

            public DtoBuilder Comments(string comments)
            {
                _comments = comments;
                return this;
            }

            public OfferOperationDto Build()
            {
                return new OfferOperationDto
                {
                    Comments = _comments,
                    CompanyId = _companyId,
                    MaterialId = _materialId,
                    Unit = _unit,
                    UnitPrice = _unitPrice
                };
            }
        }
    }
}