using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public OfferService(IOfferRepository offerRepository,
            ICompanyRepository companyRepository,
            IMaterialRepository materialRepository,
            IMapper mapper)
        {
            _materialRepository = materialRepository;
            _offerRepository = offerRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public OfferDto Add(OfferOperationDto operation)
        {
            var offer = new Offer()
            {
                Comments = operation.Comments,
                Company = _companyRepository.GetById(operation.CompanyId) ?? throw new NotFoundException("company"),
                LastModification = DateTime.Now,
                Material = _materialRepository.GetById(operation.MaterialId) ?? throw new NotFoundException("material"),
                Unit = operation.Unit,
                UnitPrice = operation.UnitPrice
            };
            return _mapper.Map<Offer, OfferDto>(_offerRepository.Add(offer));
        }

        public void Delete(Guid id)
        {
            _offerRepository.Remove(GetOffer(id));
        }

        public OfferDto GetById(Guid id)
        {
            return _mapper.Map<Offer, OfferDto>(GetOffer(id));
        }

        public IList<OfferDto> GetCompanyOffers(Guid id)
        {
            return _mapper.Map<IList<Offer>, IList<OfferDto>>(_offerRepository
                .GetAll()
                .Where(e => e.Company.Id.Equals(id))
                .ToList());
        }

        public IList<OfferDto> GetMaterialOffers(Guid id)
        {
            return _mapper.Map<IList<Offer>, IList<OfferDto>>(_offerRepository
                .GetAll()
                .Where(e => e.Material.Id.Equals(id))
                .ToList());
        }

        public OfferDto Update(Guid id, OfferOperationDto operation)
        {
            var offer = GetOffer(id);
            offer.Unit = operation.Unit;
            offer.Comments = operation.Comments;
            offer.UnitPrice = operation.UnitPrice;
            offer.LastModification = DateTime.Now;
            if (!offer.Company.Id.Equals(operation.CompanyId))
            {
                offer.Company = _companyRepository.GetById(operation.CompanyId) ??
                                throw new NotFoundException("company");
            }

            if (!offer.Material.Id.Equals(operation.MaterialId))
            {
                offer.Material = _materialRepository.GetById(operation.MaterialId) ??
                                 throw new NotFoundException("material");
            }
            return _mapper.Map<Offer, OfferDto>(_offerRepository.Update(offer));
        }

        private Offer GetOffer(Guid id)
        {
            return _offerRepository.GetById(id) ?? throw new NotFoundException("offer");
        }
    }
}
