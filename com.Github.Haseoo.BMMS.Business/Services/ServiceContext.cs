using AutoMapper;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data.Repositories;

namespace com.Github.Haseoo.BMMS.Business.Services
{
    public class ServiceContext
    {
        public IMaterialService MaterialService { get; }
        public ICompanyService CompanyService { get; }
        public IOfferService OfferService { get; }

        public ServiceContext(IMapper mapper)
        {
            var repositoryContext = new RepositoryContext();
            MaterialService = new MaterialService(repositoryContext.MaterialRepository, mapper);
            CompanyService = new CompanyService(repositoryContext.CompanyRepository, mapper);
            OfferService = new OfferService(repositoryContext.OfferRepository,
                repositoryContext.CompanyRepository,
                repositoryContext.MaterialRepository,
                mapper);
        }
    }
}