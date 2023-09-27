FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/Garther.Comments.Indexer/Garther.Comments.Indexer.csproj", "src/services/Garther.Comments.Indexer/"]
RUN dotnet restore "src/services/Garther.Comments.Indexer/Garther.Comments.Indexer.csproj"
COPY . .
WORKDIR "/src/src/services/Garther.Comments.Indexer"
RUN dotnet build "Garther.Comments.Indexer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Garther.Comments.Indexer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Garther.Comments.Indexer.dll"]
