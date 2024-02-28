#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PokemonTeamBuilder.Server/PokemonTeamBuilder.Server.csproj", "PokemonTeamBuilder.Server/"]
RUN dotnet restore "PokemonTeamBuilder.Server/PokemonTeamBuilder.Server.csproj"
COPY . .
WORKDIR "/src/PokemonTeamBuilder.Server"
RUN dotnet build "PokemonTeamBuilder.Server.csproj" -c Release -o /app/build

FROM dotnet-build AS publish
RUN dotnet publish "PokemonTeamBuilder.Server.csproj" -c Release -o /app/publish

FROM node:20 AS node-build
WORKDIR /src
COPY ["PokemonTeamBuilder.Client/package.json", "PokemonTeamBuilder.Client/"]
COPY ["PokemonTeamBuilder.Client/package-lock.json", "PokemonTeamBuilder.Client/"]
RUN npm install
COPY . .
WORKDIR "/src/PokemonTeamBuilder.Client"
RUN npm run build

FROM base AS final
WORKDIR /app
RUN mkdir /app/wwwroot
COPY --from=publish /app/publish .
COPY --from=node-build /node/build app/wwwroot
ENTRYPOINT ["dotnet", "PokemonTeamBuilder.Server.dll"]
