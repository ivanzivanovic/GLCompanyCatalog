# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["GL.CompanyCatalog.WebApp/GL.CompanyCatalog.WebApp.csproj", "GL.CompanyCatalog.WebApp/"]
RUN dotnet restore "GL.CompanyCatalog.WebApp/GL.CompanyCatalog.WebApp.csproj"

COPY . .
WORKDIR "/src/GL.CompanyCatalog.WebApp"
RUN dotnet publish -c Release -o /app/publish

# Runtime stage - nginx služi statički sadržaj
FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
