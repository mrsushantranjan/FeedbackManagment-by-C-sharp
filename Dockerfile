# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["FeedbackManagment.csproj", "./"]
RUN dotnet restore "FeedbackManagment.csproj"

# Copy remaining files and build release
COPY . .
RUN dotnet publish "FeedbackManagment.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render exposes and binds to port 10000 by default
ENV PORT=10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "FeedbackManagment.dll"]
