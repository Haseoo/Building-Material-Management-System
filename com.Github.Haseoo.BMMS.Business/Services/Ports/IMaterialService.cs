using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using System;
using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface IMaterialService : ITransactionalService<MaterialOperationDto, MaterialDto>
    {
        IList<MaterialDto> GetList();

        IList<MaterialDto> SearchByName(string partialName);

        MaterialDto GetById(Guid id);

        MaterialDto Update(Guid id, MaterialOperationDto operation);
    }
}