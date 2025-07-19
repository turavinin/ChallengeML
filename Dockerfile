
# Imagen base de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Copiar todos los csproj de cada capa
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChallengeML/ChallengeML.csproj", "ChallengeML/"]
COPY ["ChallengeML.Application/ChallengeML.Application.csproj", "ChallengeML.Application/"]
COPY ["ChallengeML.Domain/ChallengeML.Domain.csproj", "ChallengeML.Domain/"]
COPY ["ChallengeML.Repository/ChallengeML.Repository.csproj", "ChallengeML.Repository/"]

# Restaurar dependencias
RUN dotnet restore "./ChallengeML/ChallengeML.csproj"
COPY . .
WORKDIR "/src/ChallengeML"
RUN dotnet build "./ChallengeML.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChallengeML.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengeML.dll"]
