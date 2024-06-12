# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Game/Game.csproj", "Game/"]
RUN dotnet restore "Game/Game.csproj"
COPY . .
WORKDIR "/src/Game"
RUN dotnet build "Game.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Game.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Game.dll"]
