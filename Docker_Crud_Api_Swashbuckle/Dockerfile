#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Docker_Crud_Api_Swashbuckle/Docker_Crud_Api_Swashbuckle.csproj", "Docker_Crud_Api_Swashbuckle/"]
RUN dotnet restore "Docker_Crud_Api_Swashbuckle/Docker_Crud_Api_Swashbuckle.csproj"
COPY . .
WORKDIR "/src/Docker_Crud_Api_Swashbuckle"
RUN dotnet build "Docker_Crud_Api_Swashbuckle.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker_Crud_Api_Swashbuckle.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker_Crud_Api_Swashbuckle.dll"]
