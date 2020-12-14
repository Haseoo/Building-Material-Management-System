using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.WinForms.Configuration
{
    public static class AutoMapper
    {
        public static IMapper Mapper { get; }

        static AutoMapper () 
        {
            Mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Material, MaterialDto>().ConstructUsing(s => MaterialDto.From(s));
                c.CreateMap<Company, CompanyDto>().ConvertUsing(s => CompanyDto.From(s));
                c.CreateMap<CompanyContactData, CompanyContactDataDto>().ConvertUsing(s => CompanyContactDataDto.From(s));
                c.CreateMap<Offer, OfferDto>().ConvertUsing(s => OfferDto.From(s));
            }).CreateMapper();
        }


    }
}
