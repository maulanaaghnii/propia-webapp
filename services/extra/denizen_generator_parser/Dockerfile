FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/extra/denizen_generator_parser/denizen_generator_parser.csproj", "services/extra/denizen_generator_parser/"]
RUN dotnet restore "services/extra/denizen_generator_parser/denizen_generator_parser.csproj"
COPY . .
WORKDIR "/src/services/extra/denizen_generator_parser"
RUN dotnet build "denizen_generator_parser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "denizen_generator_parser.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "denizen_generator_parser.dll"]
