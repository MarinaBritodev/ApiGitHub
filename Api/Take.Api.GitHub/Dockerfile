FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["Take.Api.GitHub.Facades/Take.Api.GitHub.Facades.csproj", "Take.Api.GitHub.Facades/"]
COPY ["Take.Api.GitHub.Models/Take.Api.GitHub.Models.csproj", "Take.Api.GitHub.Models/"]
COPY ["Take.Api.GitHub.Services/Take.Api.GitHub.Services.csproj", "Take.Api.GitHub.Services/"]
COPY ["Take.Api.GitHub/Take.Api.GitHub.csproj", "Take.Api.GitHub/"]

RUN dotnet restore "Take.Api.GitHub/Take.Api.GitHub.csproj"
COPY . .
WORKDIR "/src/Take.Api.GitHub"
RUN dotnet build "Take.Api.GitHub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Take.Api.GitHub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Take.Api.GitHub.dll"]