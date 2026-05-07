FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Restore
COPY ["JewelStore.csproj", "./"]
RUN dotnet restore "JewelStore.csproj"

# Build
COPY . .
RUN dotnet build "JewelStore.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "JewelStore.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JewelStore.dll"]
