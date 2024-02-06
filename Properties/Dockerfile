# Use the official .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.402 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET Core SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0.402 AS build
WORKDIR /src
COPY ["APIProject.csproj", ""]
RUN dotnet restore "./APIProject.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "APIProject.csproj" -c Release -o /app/build

# Build and publish the application
FROM build AS publish
RUN dotnet publish "APIProject.csproj" -c Release -o /app/publish

# Final stage/image for running the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIProject.dll"]
