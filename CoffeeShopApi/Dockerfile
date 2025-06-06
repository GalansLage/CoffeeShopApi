# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Fase de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 1. Configura el directorio de trabajo
WORKDIR /src

# 2. Copia SOLO el archivo .csproj primero (para cache de dependencias)
COPY ["CoffeeShopApi/CoffeeShopApi.csproj", "CoffeeShopApi/"]
RUN dotnet restore "CoffeeShopApi/CoffeeShopApi.csproj"

# 3. Copia todo el resto del código
COPY . .

# 4. Construye y publica
RUN dotnet build "CoffeeShopApi/CoffeeShopApi.csproj" -c Release -o /app/build
RUN dotnet publish "CoffeeShopApi/CoffeeShopApi.csproj" -c Release -o /app/publish

# Fase de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT ["dotnet", "CoffeeShopApi.dll"]