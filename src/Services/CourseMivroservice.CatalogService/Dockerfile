FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/CourseMivroservice.CatalogService/CourseMivroservice.CatalogService.csproj", "src/Services/CourseMivroservice.CatalogService/"]
RUN dotnet restore "src/Services/CourseMivroservice.CatalogService/CourseMivroservice.CatalogService.csproj"
COPY . .
WORKDIR "/src/src/Services/CourseMivroservice.CatalogService"
RUN dotnet build "CourseMivroservice.CatalogService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseMivroservice.CatalogService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseMivroservice.CatalogService.dll"]
