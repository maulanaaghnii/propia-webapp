FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/extra/denizen-generator/denizen-generator.csproj", "services/extra/denizen-generator/"]
RUN dotnet restore "services/extra/denizen-generator/denizen-generator.csproj"
COPY . .
WORKDIR "/src/services/extra/denizen-generator"
RUN dotnet build "denizen-generator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "denizen-generator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "denizen-generator.dll"]
