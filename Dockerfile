# FROM microsoft/aspnetcore:1
# LABEL Name=safemedia Version=0.0.1
# ARG source=.
# WORKDIR /app
# EXPOSE 3000
# COPY $source .
# ENTRYPOINT dotnet safemedia.dll
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /safemedia

# copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj .
RUN dotnet restore

# copy everything else and build app
COPY . .

# set up node
ENV NODE_VERSION 8.9.4
ENV NODE_DOWNLOAD_SHA 21fb4690e349f82d708ae766def01d7fec1b085ce1f5ab30d9bda8ee126ca8fc
RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs

#publish
RUN dotnet build

FROM build AS publish
WORKDIR /safemedia
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
ENV ASPNETCORE_URLS http://+:3000
#;https://+:3001
WORKDIR /safemedia
COPY --from=publish /safemedia/out ./
ENTRYPOINT ["dotnet", "SafeMedia.dll"]