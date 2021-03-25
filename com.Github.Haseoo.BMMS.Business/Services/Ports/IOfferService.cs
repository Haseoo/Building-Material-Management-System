using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using System;
using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface IOfferService : ITransactionalService<OfferOperationDto, OfferDto>
    {
        IList<OfferDto> GetCompanyOffers(Guid id);

        IList<OfferDto> GetMaterialOffers(Guid id);

        OfferDto GetById(Guid id);

        OfferDto Update(Guid id, OfferOperationDto operation);
    }
}