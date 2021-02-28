using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;

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
