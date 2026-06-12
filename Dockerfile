# ── Build stage ──
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore first (layer caching)
COPY RemyEnMarit/RemyEnMarit.csproj RemyEnMarit/
RUN dotnet restore RemyEnMarit/RemyEnMarit.csproj

# Copy everything else and publish
COPY . .
WORKDIR /src/RemyEnMarit
RUN dotnet publish -c Release -o /app/publish

# ── Runtime stage ──
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "JoseEnLaura.dll"]

