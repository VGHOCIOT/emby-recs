# Use a base image with .NET SDK for building plugins
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install any additional tools if needed
RUN apt-get update && apt-get install -y unzip

# Copy your plugin code into the container
WORKDIR /app
COPY . .

# Build the plugin
RUN dotnet build -c Release

# Second stage for running Emby Server (optional)
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime

# # Install curl and unzip
# RUN apt-get update && apt-get install -y curl unzip

# # Download and set up Emby Server
# WORKDIR /emby
# RUN curl -O https://emby.media/latest_server.zip && unzip latest_server.zip

# # Copy the built plugin
# COPY --from=build /app/bin/Release/net6.0/*.dll /emby/plugins/

# # Expose the Emby server port
# EXPOSE 8096

# # Command to start Emby Server
# CMD ["dotnet", "MediaBrowser.Server.dll"]
