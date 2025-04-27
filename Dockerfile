# Use official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy everything
COPY . .

# Restore dependencies
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o out

# Use a lighter runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the build output
COPY --from=build /app/out .

# Expose port (اختياري لو محتاج توصل للبورت)
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "SportInApp.dll"]
