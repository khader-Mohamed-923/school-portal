# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy central package management file (needed for CPM restore)
COPY ["Directory.Packages.props", "."]

# Copy csproj and restore as distinct layers
COPY ["SchoolPortal.Students/SchoolPortal.Students.csproj", "SchoolPortal.Students/"]
RUN dotnet restore "SchoolPortal.Students/SchoolPortal.Students.csproj"

# Copy everything else and publish
COPY SchoolPortal.Students/ SchoolPortal.Students/
RUN dotnet publish "SchoolPortal.Students/SchoolPortal.Students.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SchoolPortal.Students.dll"]
