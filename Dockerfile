# escape=`

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build
WORKDIR /app
COPY . ./
ARG BUILD_VERSION=0.0.0
RUN dotnet restore TaskManagerAPI.csproj
RUN dotnet publish TaskManagerAPI.csproj -c Release -o out -p:Version=%BUILD_VERSION% -p:FileVersion=%BUILD_VERSION% -p:AssemblyVersion=%BUILD_VERSION%


# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-ltsc2022 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "TaskManagerAPI.dll"]
