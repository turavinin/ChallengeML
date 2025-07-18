using AutoMapper;
using ChallengeML.Domain.Entities;
using ChallengeML.Domain.Entities.Filters;
using ChallengeML.DTO.Product.Filters;
using ChallengeML.DTO.Product.Response;

namespace ChallengeML.Mapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductFiltersRequest, ProductFilters>();
        }
    }
}
