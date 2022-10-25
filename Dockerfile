FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
COPY ./src/movie_app/publish .
ENTRYPOINT [“dotnet”, “movie_app_csharp.dll”]