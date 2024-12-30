# CarGlass-Teste
# Configuração de Ambiente com Docker e .NET SDK 9.0  

Este guia descreve os passos para configurar um ambiente utilizando Docker e instalar o .NET SDK 9.0 no Ubuntu 24.04.

---

## 1. Inicializando o Container Docker  

Execute o comando abaixo para criar e iniciar um container:  

docker run -it --name prova `
  --network osm-network `
  -v "C:\Projetos\Nprimo:/data" `
  -p 8084:8080 `
  -p 84:80 `
  ubuntu:24.04 `
  bash

//Para acessar container
docker exec -it prova /bin/bash

//Execute os comandos
apt-get update && apt-get upgrade -y

apt-get install -y wget apt-transport-https software-properties-common

apt-get update

apt-get install -y sudo

//Baixe o SDK diretamente do site oficial:
wget https://dotnetcli.azureedge.net/dotnet/Sdk/9.0.100/dotnet-sdk-9.0.100-linux-x64.tar.gz

//Extraia os arquivos:

mkdir -p /usr/share/dotnet
tar -xzvf dotnet-sdk-9.0.100-linux-x64.tar.gz -C /usr/share/dotnet

//Adicione o executável ao PATH:
ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

//Verifique a instalação:
dotnet --version