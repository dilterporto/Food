FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Food.Orders.Adapters.Rest/Food.Orders.Adapters.Rest.csproj", "Food.Orders.Adapters.Rest/"]
RUN dotnet restore "Food.Orders.Adapters.Rest/Food.Orders.Adapters.Rest.csproj"
COPY . .
WORKDIR "/src/Food.Orders.Adapters.Rest"
RUN dotnet build "Food.Orders.Adapters.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Food.Orders.Adapters.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Food.Orders.Adapters.Rest.dll"]
