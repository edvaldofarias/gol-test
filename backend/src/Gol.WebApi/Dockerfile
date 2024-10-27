FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8080
EXPOSE 443

LABEL maintainer="Gol" description="Gol Teste de Backend"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

COPY . .

WORKDIR /src

RUN dotnet restore "Gol.WebApi/Gol.WebApi.csproj"

WORKDIR "/src/Gol.WebApi"

RUN dotnet build "Gol.WebApi.csproj" -c Release -o /app/build

FROM build AS tests
RUN dotnet test

FROM build AS publish
RUN dotnet publish "Gol.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gol.WebApi.dll"]