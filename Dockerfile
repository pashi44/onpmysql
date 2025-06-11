FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY *.csproj ./

RUN dotnet restore
# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out



# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "onpmysql.dll"]


