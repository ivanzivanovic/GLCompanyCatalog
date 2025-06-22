# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GL.CompanyCatalog.Api/GL.CompanyCatalog.Api.csproj", "GL.CompanyCatalog.Api/"]
COPY ["GL.CompanyCatalog.Application/GL.CompanyCatalog.Application.csproj", "GL.CompanyCatalog.Application/"]
COPY ["GL.CompanyCatalog.Domain/GL.CompanyCatalog.Domain.csproj", "GL.CompanyCatalog.Domain/"]
COPY ["GL.CompanyCatalog.Identity/GL.CompanyCatalog.Identity.csproj", "GL.CompanyCatalog.Identity/"]
COPY ["GL.CompanyCatalog.Infrastructure/GL.CompanyCatalog.Infrastructure.csproj", "GL.CompanyCatalog.Infrastructure/"]
COPY ["GL.CompanyCatalog.Persistence/GL.CompanyCatalog.Persistence.csproj", "GL.CompanyCatalog.Persistence/"]
RUN dotnet restore "./GL.CompanyCatalog.Api/GL.CompanyCatalog.Api.csproj"
COPY . .
WORKDIR "/src/GL.CompanyCatalog.Api"
RUN dotnet build "./GL.CompanyCatalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GL.CompanyCatalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GL.CompanyCatalog.Api.dll"]