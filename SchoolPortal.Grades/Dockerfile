# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy central package management file (needed for CPM restore)
COPY ["Directory.Packages.props", "."]

# Copy csproj and restore as distinct layers
COPY ["SchoolPortal.Grades/SchoolPortal.Grades.csproj", "SchoolPortal.Grades/"]
RUN dotnet restore "SchoolPortal.Grades/SchoolPortal.Grades.csproj"

# Copy everything else and publish
COPY SchoolPortal.Grades/ SchoolPortal.Grades/
RUN dotnet publish "SchoolPortal.Grades/SchoolPortal.Grades.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SchoolPortal.Grades.dll"]
