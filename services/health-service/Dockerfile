FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/health-service/health-service.csproj", "services/health-service/"]
RUN dotnet restore "services/health-service/health-service.csproj"
COPY . .
WORKDIR "/src/services/health-service"
RUN dotnet build "health-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "health-service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "health-service.dll"]
