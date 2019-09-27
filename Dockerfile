FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY ./src/i18u.Repositories.Mongo/i18u.Repositories.Mongo.csproj ./i18u.Repositories.Mongo/
COPY ./src/i18u.Repositories.Tests/i18u.Repositories.Tests.csproj ./i18u.Repositories.Tests/
COPY ./src/i18u.Repositories.sln ./

RUN dotnet restore

COPY ./src/ ./
RUN dotnet publish -c Release -o out --no-restore

FROM microsoft/dotnet:sdk
WORKDIR /app

COPY --from=build-env /app/ .

ENTRYPOINT [ "dotnet", "test", "i18u.Repositories.Tests" ]
