FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Web3Laliberte.OperationsAPI.csproj", "./"]
RUN dotnet restore "Web3Laliberte.OperationsAPI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Web3Laliberte.OperationsAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Web3Laliberte.OperationsAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:4000
RUN chmod 644 /app/appsettings.json

ENTRYPOINT ["dotnet", "Web3Laliberte.OperationsAPI.dll"]



