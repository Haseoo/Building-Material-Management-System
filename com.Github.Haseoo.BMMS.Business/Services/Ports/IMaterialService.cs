
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using System;
using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface IMaterialService
    {
        List<MaterialDto> GetList();
        MaterialDto GetById(Guid id);
        MaterialDto Add(MaterialOperationDto operation);
        MaterialDto Update(Guid id, MaterialOperationDto operation);
        void Delete(Guid id);
    }
}
