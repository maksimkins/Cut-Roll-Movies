FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY ./Cut-Roll-Movies/src/Cut-Roll-Movies.Api/*.csproj .Cut-Roll-Movies/src/Cut-Roll-Movies.Api/
COPY ./Cut-Roll-Movies/src/Cut-Roll-Movies.Infrastructure/*.csproj .Cut-Roll-Movies/src/Cut-Roll-Movies.Infrastructure/
COPY ./Cut-Roll-Movies/src/Cut-Roll-Movies.Core/*.csproj .Cut-Roll-Movies/src/Cut-Roll-Movies.Core/

COPY . .

RUN dotnet publish Cut-Roll-Movies/src/Cut-Roll-Movies.Api/Cut-Roll-Movies.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "Cut-Roll-Movies.Api.dll" ]