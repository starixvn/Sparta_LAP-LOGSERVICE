FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Famex.Athena.Microservice.Logging/Famex.Athena.Microservice.Logging.csproj", "Famex.Athena.Microservice.Logging/"]
RUN dotnet restore "Famex.Athena.Microservice.Logging/Famex.Athena.Microservice.Logging.csproj"
COPY . .
WORKDIR "/src/Famex.Athena.Microservice.Logging"
RUN dotnet build "Famex.Athena.Microservice.Logging.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Famex.Athena.Microservice.Logging.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Famex.Athena.Microservice.Logging.dll"]