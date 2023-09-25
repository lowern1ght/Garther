FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/api/Garther.Identity.Api/Garther.Identity.Api.csproj", "src/api/Garther.Identity.Api/"]
RUN dotnet restore "src/api/Garther.Identity.Api/Garther.Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/api/Garther.Identity.Api"
RUN dotnet build "Garther.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Garther.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Garther.Identity.Api.dll"]
