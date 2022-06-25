using AutoMapper;
using PromoProjectCCAI.Dtos;
using PromoProjectCCAI.Models;

namespace PromoProjectCCAI.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Store:
            CreateMap<StoreDto, StoreModel>().ReverseMap();

            // Promo:
            CreateMap<PromoDto, PromoModel>().ReverseMap();
        }
    }
}
