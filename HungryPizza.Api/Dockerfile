#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HungryPizza.Api/HungryPizza.Api.csproj", "HungryPizza.Api/"]
RUN dotnet restore "HungryPizza.Api/HungryPizza.Api.csproj"
COPY . .
WORKDIR "/src/HungryPizza.Api"
RUN dotnet build "HungryPizza.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HungryPizza.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HungryPizza.Api.dll"]