using ChallengeML.Application.Services;
using ChallengeML.Domain.Interfaces.Repositories;
using ChallengeML.Domain.Interfaces.Services;
using ChallengeML.Repository.Repositories;

namespace ChallengeML.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            #region DatabaseConnection

            #endregion

            #region Services
            services.AddTransient<IProductService, ProductService>();
            #endregion

            #region Repositories    
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion

            return services;
        }
    }
}
