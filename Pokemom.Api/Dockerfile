FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o publishdir

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
EXPOSE 5555
WORKDIR /app
COPY --from=build /app/publishdir .
ENTRYPOINT ["dotnet", "Pokemom.Api.dll"]