# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the entire solution and restore dependencies
COPY CodeAssistant/CodeAssistant.sln ./
COPY CodeAssistant/CodeAssistant/*.csproj ./CodeAssistant/
COPY CodeAssistant/CodeAssistant/ ./CodeAssistant/

WORKDIR /src/CodeAssistant
RUN dotnet restore

# Build the app
RUN dotnet publish -c Release -o /app/publish

# Use a runtime image for the final container
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CodeAssistant.dll"]
