# Build and run the EmployeeApp ASP.NET Core MVC application using
# multi‑stage Dockerfile. The first stage compiles and publishes the
# application, while the second stage runs it on the slimmer runtime
# image.

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy project file and restore dependencies. Doing this before copying
# the entire source enables Docker layer caching to avoid repeated
# downloads when only application code changes.
COPY EmployeeApp.csproj ./
RUN dotnet restore ./EmployeeApp.csproj

# Copy the remaining source code into the container and publish the
# application in Release configuration. The output will be placed in
# /app/publish.
COPY . .
RUN dotnet publish EmployeeApp.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
EXPOSE 80

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Start the application when the container runs
ENTRYPOINT ["dotnet", "EmployeeApp.dll"]