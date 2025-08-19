# =========================
# Stage 1: Build & Publish
# =========================
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY EmployeeApp.csproj ./
RUN dotnet restore EmployeeApp.csproj
COPY . .
RUN dotnet publish EmployeeApp.csproj -c Release -o /app/publish

# =========================
# Stage 2: Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EmployeeApp.dll"]
