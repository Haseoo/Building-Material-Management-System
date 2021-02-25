using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface ICompanyService : ITransactionalService<CompanyOperationDto, CompanyDto>
    {
        List<CompanyDto> GetList();
        List<CompanyDto> SearchByName(string partialName);
        CompanyDto GetById(Guid id);
        new CompanyDto Add(CompanyOperationDto operation);
        CompanyDto Update(Guid id, CompanyOperationDto operation);
        new void Delete(Guid id);
    }
}
