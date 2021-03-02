using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.WinForms.Configuration
{
    public static class MapperConf
    {
        public static IMapper Mapper { get; }

        static MapperConf () 
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
