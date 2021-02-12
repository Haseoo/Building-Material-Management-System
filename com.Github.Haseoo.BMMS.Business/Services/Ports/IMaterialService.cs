
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using System;
using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface IMaterialService : ITransactionalService<MaterialOperationDto, MaterialDto>
    {
        List<MaterialDto> GetList();
        List<MaterialDto> SearchByName(string partialName);
        MaterialDto GetById(Guid id);
        new MaterialDto Add(MaterialOperationDto operation);
        MaterialDto Update(Guid id, MaterialOperationDto operation);
        new void Delete(Guid id);
    }
}
