FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /app

COPY src/*.sln .
COPY src/i18u.Repositories.Tests/*.csproj i18u.Repositories.Tests/
COPY src/i18u.Repositories.Mongo/*.csproj i18u.Repositories.Mongo/
RUN dotnet restore

COPY . .
RUN dotnet build -c Release

ENTRYPOINT ["dotnet","test","/p:CollectCoverage=true"]
