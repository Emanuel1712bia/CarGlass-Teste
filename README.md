﻿# CarGlass-Teste
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


// Coloque todos os arquivos em 
  
  "C:\Projetos\Nprimo"

//Acesse o diretorio o 

  cd C:\Projetos\Nprimo

// Para interagir com o contêiner: [Execute no powershell em modo ADM]

  docker-compose up --build

// Para rodar novamente ou recriar se necessário [Execute no powershell em modo ADM]
  docker run -it --name prova-novo \
  -v "$(pwd)/Nprimo:/data" \
  -p 8084:8080 \
  -p 84:80 \
  minha-imagem-root:1.0 \
  /bin/bash


Segue a sequência de execução dos consoles para o fluxo apresentado:

Caso precise acessar o Linux no contaienr [Execute no powershell em modo ADM]
  docker exec -it prova /bin/bash

// --> Execução da API (NPrimoAPI)
// --> Execução dos Testes Unitários (NPrimoAPI.Tests)
// --> Execução do Programa Console (NPrimoAPI.Console)


Como Rodar

*) Execução da API (NPrimoAPI)

  //Dentro do container acesse o diretório
    
    cd /data/NPRIMO

  //Restaurar pacotes
    
    dotnet restore

  //Compilar
    
    dotnet build

  //Executar API (vai rodar na porta 8080 interna do container)
    
    dotnet run //Apontei para 8084
    //ou
    dotnet run --project NprimoAPI  //N Testei

  //Para testar a API
    
    http://localhost:8084/Divisores/divisores?numero=45

    http://localhost:8084/Divisores/divisoresprimos?numero=45

*) Execução dos Testes Unitários (NPrimoAPI.Tests)

  // Compilar em /data/NprimoAPI.Tests que representa  C:\Projetos\Nprimo\NprimoAPI.Tests 
  
    dotnet restore
  
    dotnet build

  //Em um diretorio antes do projeto
  // Em /data que representa C:\Projetos\Nprimo

    dotnet test NprimoAPI.Tests


*) Execução do Programa Console (NPrimoAPI.Console)

   //Acessar o diretorio pelo powershell dentro do container
     
     cd /data/NPRIMO/dotnet run

   // Restaurar pacotes

     dotnet restore

   // Compilar

     dotnet build

   // Rodar

     dotnet run

