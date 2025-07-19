using ChallengeML.DependencyInjection;
using ChallengeML.Mapper;
using ChallengeML.Middlewares;
using ChallengeML.OpenApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApiConfiguration();
builder.Services.ConfigureDependencyInjection(builder.Configuration);
builder.Services.AddAutoMapperConfig();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MercadoLibre Challenge API V1");
    options.RoutePrefix = string.Empty;
});

app.UseExceptionMiddleware();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
