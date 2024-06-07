# Используем образ ASP.NET Core Runtime в качестве базового образа
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Используем образ SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["lib_tz1/lib_tz1.csproj", "lib_tz1/"]
RUN dotnet restore "lib_tz1/lib_tz1.csproj"
COPY . .
WORKDIR "/src/lib_tz1"
RUN dotnet build "lib_tz1.csproj" -c Release -o /app/build

# Публикация приложения
FROM build AS publish
RUN dotnet publish "lib_tz1.csproj" -c Release -o /app/publish

# Окончательный образ для запуска
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lib_tz1.dll"]
