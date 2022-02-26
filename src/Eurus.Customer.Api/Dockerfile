FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Eurus.Customer.Api/Eurus.Customer.Api.csproj", "Eurus.Customer.Api/"]
RUN dotnet restore "src/Eurus.Customer.Api/Eurus.Customer.Api.csproj"
COPY . .
WORKDIR "/src/Eurus.Customer.Api"
RUN dotnet build "Eurus.Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eurus.Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eurus.Customer.Api.dll"]
