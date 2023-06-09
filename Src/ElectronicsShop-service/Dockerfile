FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001
ENV ASPNETCORE_ENVIRONMENT=Development

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ElectronicsShop-service/ElectronicsShop-service.csproj", "ElectronicsShop-service/"]
RUN dotnet restore "ElectronicsShop-service/ElectronicsShop-service.csproj"
COPY . .
WORKDIR "/src/ElectronicsShop-service"
RUN dotnet build "ElectronicsShop-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElectronicsShop-service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /src/ElectronicsShop-service
RUN dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "run"]
