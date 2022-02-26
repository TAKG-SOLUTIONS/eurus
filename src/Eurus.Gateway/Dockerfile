FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/gateway/Eurus.Gateway/Eurus.Gateway.csproj", "Eurus.Gateway/"]
RUN dotnet restore "src/gateway/Eurus.Gateway/Eurus.Gateway.csproj"
COPY . .
WORKDIR "/src/Eurus.Gateway"
RUN dotnet build "Eurus.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eurus.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eurus.Gateway.dll"]
