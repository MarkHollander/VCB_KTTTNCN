#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Qlud.KTTTNCN.Web.Mvc/Qlud.KTTTNCN.Web.Mvc.csproj", "src/Qlud.KTTTNCN.Web.Mvc/"]
COPY ["src/Qlud.KTTTNCN.Web.Core/Qlud.KTTTNCN.Web.Core.csproj", "src/Qlud.KTTTNCN.Web.Core/"]
COPY ["src/Qlud.KTTTNCN.Application/Qlud.KTTTNCN.Application.csproj", "src/Qlud.KTTTNCN.Application/"]
COPY ["src/Qlud.KTTTNCN.Application.Shared/Qlud.KTTTNCN.Application.Shared.csproj", "src/Qlud.KTTTNCN.Application.Shared/"]
COPY ["src/Qlud.KTTTNCN.Core.Shared/Qlud.KTTTNCN.Core.Shared.csproj", "src/Qlud.KTTTNCN.Core.Shared/"]
COPY ["src/Qlud.KTTTNCN.Core/Qlud.KTTTNCN.Core.csproj", "src/Qlud.KTTTNCN.Core/"]
COPY ["src/Qlud.KTTTNCN.EntityFrameworkCore/Qlud.KTTTNCN.EntityFrameworkCore.csproj", "src/Qlud.KTTTNCN.EntityFrameworkCore/"]
COPY ["src/Qlud.KTTTNCN.GraphQL/Qlud.KTTTNCN.GraphQL.csproj", "src/Qlud.KTTTNCN.GraphQL/"]
RUN dotnet restore "src/Qlud.KTTTNCN.Web.Mvc/Qlud.KTTTNCN.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/Qlud.KTTTNCN.Web.Mvc"
RUN dotnet build "Qlud.KTTTNCN.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Qlud.KTTTNCN.Web.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Qlud.KTTTNCN.Web.Mvc.dll"]
