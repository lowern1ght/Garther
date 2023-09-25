FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/api/Garther.WebApi/Garther.WebApi.csproj", "src/api/Garther.WebApi/"]
RUN dotnet restore "src/api/Garther.WebApi/Garther.WebApi.csproj"
COPY . .
WORKDIR "/src/src/api/Garther.WebApi"
RUN dotnet build "Garther.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Garther.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Garther.WebApi.dll"]
