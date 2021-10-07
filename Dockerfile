#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["MarvelHeroStory.Web/MarvelHeroStory.Web.csproj", "MarvelHeroStory.Web/"]
COPY ["MarvelHeroStory.Infraestructure/MarvelHeroStory.Infraestructure.csproj", "MarvelHeroStory.Infraestructure/"]
COPY ["MarvelHeroStory.ApplicationCore/MarvelHeroStory.ApplicationCore.csproj", "MarvelHeroStory.ApplicationCore/"]
COPY ["MarvelHeroStory.Domain/MarvelHeroStory.Domain.csproj", "MarvelHeroStory.Domain/"]
RUN dotnet restore "MarvelHeroStory.Web/MarvelHeroStory.Web.csproj"
COPY . .
WORKDIR "/src/MarvelHeroStory.Web"
RUN dotnet build "MarvelHeroStory.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarvelHeroStory.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarvelHeroStory.Web.dll"]