FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CLR21Example.sln ./
COPY CLR21Example/CLR21Example.csproj CLR21Example/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/CLR21Example
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CLR21Example.dll"]
