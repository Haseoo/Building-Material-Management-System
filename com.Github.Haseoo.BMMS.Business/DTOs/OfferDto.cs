using com.Github.Haseoo.BMMS.Data.Entities;
using System;

namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public sealed class OfferDto : EntityDto
    {
        public CompanyDto Company { get; }
        public MaterialDto Material { get; }
        public decimal UnitPrice { get; }
        public string Unit { get; }
        public string Comments { get; }
        public DateTime LastModification { get; }

        private OfferDto(Guid id,
            CompanyDto company,
            MaterialDto material,
            decimal unitPrice,
            string unit,
            string comments,
            DateTime lastModification) : base(id)
        {
            Company = company;
            Material = material;
            UnitPrice = unitPrice;
            Unit = unit;
            Comments = comments;
            LastModification = lastModification;
        }

        public static OfferDto From(Offer offer)
        {
            return new OfferDto(offer.Id,
                CompanyDto.From(offer.Company),
                MaterialDto.From(offer.Material),
                offer.UnitPrice,
                offer.Unit,
                offer.Comments,
                offer.LastModification);
        }
    }
}