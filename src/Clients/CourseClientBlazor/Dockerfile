FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Clients/CourseClientBlazor/CourseClientBlazor.csproj", "CourseClientBlazor/"]
RUN dotnet restore "src/Clients/CourseClientBlazor/CourseClientBlazor.csproj"
COPY . .
WORKDIR "/src/CourseClientBlazor"
RUN dotnet build "CourseClientBlazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseClientBlazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseClientBlazor.dll"]
