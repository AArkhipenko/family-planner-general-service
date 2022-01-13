#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["General.Service.Api/General.Service.Api.csproj", "General.Service.Api/"]
RUN dotnet restore "General.Service.Api/General.Service.Api.csproj"
COPY . .
WORKDIR "/src/General.Service.Api"
RUN dotnet build "General.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "General.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "General.Service.Api.dll"]