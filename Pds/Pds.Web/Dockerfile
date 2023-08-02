FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Pds.Web/Pds.Web.csproj", "Pds.Web/"]
COPY ["Pds.Api.Contracts/Pds.Api.Contracts.csproj", "Pds.Api.Contracts/"]
COPY ["Pds.Core/Pds.Core.csproj", "Pds.Core/"]
COPY ["Pds.Data/Pds.Data.csproj", "Pds.Data/"]
COPY ["Pds.Services.Models/Pds.Services.Models.csproj", "Pds.Services.Models/"]
COPY ["Pds.Mappers/Pds.Mappers.csproj", "Pds.Mappers/"]
COPY ["Pds.Web.Models/Pds.Web.Models.csproj", "Pds.Web.Models/"]
RUN dotnet restore "Pds.Web/Pds.Web.csproj"
COPY . .
WORKDIR "/src/Pds.Web"
RUN dotnet build "Pds.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pds.Web.csproj" -c Release -o /app/publish


FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY .run/nginx.conf /etc/nginx/templates/nginx.conf.template
