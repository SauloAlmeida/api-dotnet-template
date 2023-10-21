# dotnet api template

## Requisitos

Antes de começar, certifique-se de que possui os seguintes requisitos instalados:

- [.NET SDK 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Docker](https://docs.docker.com/desktop/install/windows-install/)

## Instalação

Siga as etapas abaixo para configurar e executar o projeto:

1. Clone o repositório
```bash
git clone https://github.com/SauloAlmeida/api-dotnet-template
```

2. Acesse o diretório do projeto
```bash
cd api-dotnet-template/src
```

3. Restaure as dependências
```bash
dotnet restore
```

## Execução do Projeto (Linux)

Para iniciar o projeto em modo de desenvolvimento no ambiente Linux, siga as etapas abaixo:

1. Execute o comando na pasta raiz
```bash
./docker/linux/startup-dev.sh
```

2. Acesse o Swagger
```bash
http://localhost:5000/swagger/index.html
```

Agora o seu projeto .NET API está pronto e acessível via Swagger.