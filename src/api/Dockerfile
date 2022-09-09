FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


ENV ASPNETCORE_URLS=http://+:8000;
ENV ASPNETCORE_ENVIRONMENT=Development


FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY api_mongosd.sln ./
COPY ["src/api/*.csproj", "src/api/"]
COPY ["src/aplicacao/*.csproj", "src/aplicacao/"]
COPY ["src/repositorio/*.csproj", "src/repositorio/"]
COPY ["src/dominio/*.csproj", "src/dominio/"]
RUN dotnet restore 
COPY . .

WORKDIR /src/src/aplicacao
RUN dotnet build "aplicacao.csproj" -c Release -o /app


WORKDIR "/src/src/api"
RUN dotnet build "api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]