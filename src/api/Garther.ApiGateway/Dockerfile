FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/api/Garther.ApiGateway/Garther.ApiGateway.csproj", "src/api/Garther.ApiGateway/"]
RUN dotnet restore "src/api/Garther.ApiGateway/Garther.ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/api/Garther.ApiGateway"
RUN dotnet build "Garther.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Garther.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Garther.ApiGateway.dll"]
