# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Restore dependencies first so this layer can be cached by Render/Docker.
COPY ["t11/API.csproj", "t11/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "t11/API.csproj"

COPY . .
RUN dotnet publish "t11/API.csproj" \
	--configuration Release \
	--output /app/publish \
	--no-restore \
	/p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /app/publish .

# Render provides PORT at runtime. The default makes local docker runs convenient.
EXPOSE 8080
ENTRYPOINT ["sh", "-c", "dotnet /app/API.dll --urls http://0.0.0.0:${PORT:-8080}"]
