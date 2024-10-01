FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Pds.Api/Pds.Api.csproj", "Pds.Api/"]
COPY ["Pds.Api.Contracts/Pds.Api.Contracts.csproj", "Pds.Api.Contracts/"]
COPY ["Pds.Core/Pds.Core.csproj", "Pds.Core/"]
COPY ["Pds.Data/Pds.Data.csproj", "Pds.Data/"]
COPY ["Pds.Services.Models/Pds.Services.Models.csproj", "Pds.Services.Models/"]
COPY ["Pds.Di/Pds.Di.csproj", "Pds.Di/"]
COPY ["Pds.Services/Pds.Services.csproj", "Pds.Services/"]
COPY ["Pds.Mappers/Pds.Mappers.csproj", "Pds.Mappers/"]
COPY ["Pds.Web.Models/Pds.Web.Models.csproj", "Pds.Web.Models/"]
RUN dotnet restore "Pds.Api/Pds.Api.csproj"
COPY . .
WORKDIR "/src/Pds.Api"
RUN dotnet build "Pds.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pds.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pds.Api.dll"]
