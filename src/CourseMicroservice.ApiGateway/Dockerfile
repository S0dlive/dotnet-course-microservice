FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CourseMicroservice.ApiGateway/CourseMicroservice.ApiGateway.csproj", "src/CourseMicroservice.ApiGateway/"]
RUN dotnet restore "src/CourseMicroservice.ApiGateway/CourseMicroservice.ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/CourseMicroservice.ApiGateway"
RUN dotnet build "CourseMicroservice.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseMicroservice.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseMicroservice.ApiGateway.dll"]
