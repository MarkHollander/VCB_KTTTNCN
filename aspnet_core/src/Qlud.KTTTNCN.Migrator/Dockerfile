#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Qlud.KTTTNCN.Migrator/Qlud.KTTTNCN.Migrator.csproj", "src/Qlud.KTTTNCN.Migrator/"]
COPY ["src/Qlud.KTTTNCN.EntityFrameworkCore/Qlud.KTTTNCN.EntityFrameworkCore.csproj", "src/Qlud.KTTTNCN.EntityFrameworkCore/"]
COPY ["src/Qlud.KTTTNCN.Core/Qlud.KTTTNCN.Core.csproj", "src/Qlud.KTTTNCN.Core/"]
COPY ["src/Qlud.KTTTNCN.Core.Shared/Qlud.KTTTNCN.Core.Shared.csproj", "src/Qlud.KTTTNCN.Core.Shared/"]
RUN dotnet restore "src/Qlud.KTTTNCN.Migrator/Qlud.KTTTNCN.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Qlud.KTTTNCN.Migrator"
RUN dotnet build "Qlud.KTTTNCN.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Qlud.KTTTNCN.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Qlud.KTTTNCN.Migrator.dll", "-s"]
