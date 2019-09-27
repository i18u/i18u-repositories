FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY ./src/i18u.Repositories.Mongo/i18u.Repositories.Mongo.csproj ./i18u.Repositories.Mongo/
COPY ./src/i18u.Repositories.Tests/i18u.Repositories.Tests.csproj ./i18u.Repositories.Tests/
COPY ./src/i18u.Repositories.sln ./

RUN dotnet restore

COPY ./src/ ./
RUN find | sed 's|[^/]*/|- |g'
RUN dotnet publish -c Release -o out --no-restore

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
ARG CI_COMMIT_TAG=1.0.0

COPY --from=build-env /app/i18u.Repositories.Tests/out .

ENTRYPOINT [ "dotnet", "test", "i18u.Repositories.Tests" ]
