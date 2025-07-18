namespace ChallengeML.OpenApi
{
    public static class OpenApiConfiguration
    {
        public static IServiceCollection AddOpenApiConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MercadoLibre Challenge API",
                    Version = "v1",
                    Description = "API desarrollada para el challenge de programación en Mercado Libre.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Antón Turavínin",
                        Email = "aturavinin@gmail.com.com"
                    }
                });
            });

            return services;
        }
    }

}
