FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/CourseMicroservice.CourseService/CourseMicroservice.CourseService.csproj", "CourseMicroservice.CourseService/"]
RUN dotnet restore "src/Services/CourseMicroservice.CourseService/CourseMicroservice.CourseService.csproj"
COPY . .
WORKDIR "/src/CourseMicroservice.CourseService"
RUN dotnet build "CourseMicroservice.CourseService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseMicroservice.CourseService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseMicroservice.CourseService.dll"]
