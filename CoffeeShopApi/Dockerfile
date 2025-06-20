# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Fase base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000
ENV ASPNETCORE_URLS=http://*:$PORT

# Fase de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CoffeeShopApi/CoffeeShopApi.csproj", "CoffeeShopApi/"]
RUN dotnet restore "CoffeeShopApi/CoffeeShopApi.csproj"
COPY . .
RUN dotnet build "CoffeeShopApi/CoffeeShopApi.csproj" -c Release -o /app/build

# Fase de publicación
FROM build AS publish
RUN dotnet publish "CoffeeShopApi/CoffeeShopApi.csproj" -c Release -o /app/publish 

# Fase final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoffeeShopApi.dll"]