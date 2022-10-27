FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /movie_app_csharp

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /movie_app_csharp

COPY --from=build-env /movie_app_csharp/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]