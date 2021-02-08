using AutoMapper;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data.Repositories;
using NHibernate;
using System;

namespace com.Github.Haseoo.BMMS.Business.Services
{
    public class ServiceContext
    {
        public IMaterialService MaterialService { get; }

        public ServiceContext(IMapper mapper)
        {
            RepositoryContext repositoryContext = new RepositoryContext();
            ValidatorContext validatorContext = new ValidatorContext();
            MaterialService = new MaterialService(repositoryContext, mapper);
        }
    }
}
