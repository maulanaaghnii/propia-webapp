FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/population-service/population-service.csproj", "services/population-service/"]
RUN dotnet restore "services/population-service/population-service.csproj"
COPY . .
WORKDIR "/src/services/population-service"
RUN dotnet build "population-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "population-service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "population-service.dll"]
