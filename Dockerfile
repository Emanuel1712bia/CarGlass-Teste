# Base image
FROM ubuntu:24.04

# Set up environment to avoid interactive prompts
ENV DEBIAN_FRONTEND=noninteractive

# Update system and install required packages with root permissions
RUN apt-get update && apt-get upgrade -y && \
    apt-get install -y wget apt-transport-https software-properties-common sudo && \
    apt-get clean

# Install .NET SDK
RUN wget https://dotnetcli.azureedge.net/dotnet/Sdk/9.0.100/dotnet-sdk-9.0.100-linux-x64.tar.gz && \
    mkdir -p /usr/share/dotnet && \
    tar -xzvf dotnet-sdk-9.0.100-linux-x64.tar.gz -C /usr/share/dotnet && \
    ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet && \
    rm dotnet-sdk-9.0.100-linux-x64.tar.gz

# Verify .NET installation
RUN dotnet --version

# Set working directory
WORKDIR /data

# Default command
CMD ["/bin/bash"]
