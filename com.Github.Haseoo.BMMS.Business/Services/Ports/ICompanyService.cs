using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface ICompanyService
    {
        List<CompanyDto> GetList();
        List<CompanyDto> SearchByName(string partialName);
        CompanyDto GetById(Guid id);
        CompanyDto Add(CompanyOperationDto operation);
        CompanyDto Update(Guid id, CompanyOperationDto operation);
        void Delete(Guid id);
    }
}
