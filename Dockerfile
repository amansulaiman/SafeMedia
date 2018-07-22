# FROM microsoft/aspnetcore:1
# LABEL Name=safemedia Version=0.0.1
# ARG source=.
# WORKDIR /app
# EXPOSE 3000
# COPY $source .
# ENTRYPOINT dotnet safemedia.dll
FROM node:8
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /safemedia

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . .
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

FROM microsoft/dotnet:2.1-runtime AS runtime
ENV ASPNETCORE_URLS http://+:3000;https://+:3001
WORKDIR /safemedia
COPY --from=build /safemedia/out ./
ENTRYPOINT ["dotnet", "safemedia.dll"]