# syntax=docker/dockerfile:1

## Build stage: restore dependencies and compile the service
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# Copy the project file and restore dependencies
COPY src/DiagramPersistenceServiceApi.csproj ./DiagramPersistenceServiceApi.csproj
RUN dotnet restore DiagramPersistenceServiceApi.csproj

# Copy the remaining source code and publish in Release mode
COPY src/. .
RUN dotnet publish DiagramPersistenceServiceApi.csproj -c Release -o /app/publish

## Runtime stage: run the compiled application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Configure the ASP.NET Core hosting URL and expose the HTTP port
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "DiagramPersistenceServiceApi.dll"]
