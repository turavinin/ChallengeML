using ChallengeML.Mapper.Profiles;
using AutoMapper;

namespace ChallengeML.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
            });

            return services;
        }
    }
}
