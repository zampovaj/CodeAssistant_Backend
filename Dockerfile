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

ENV MSBUILDENABLEWORKERRESOLVER=0
ENV DOTNET_MSBUILD_SDK_RESOLVER_CLI_DIR=/usr/share/dotnet
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH="$PATH:/usr/share/dotnet"

ENTRYPOINT ["dotnet", "CodeAssistant.dll"]
