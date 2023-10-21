# dotnet api template

## Requisitos

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* [Docker](https://docs.docker.com/desktop/install/windows-install/)

## Instalação

1. Clone o projeto	
```bash
https://github.com/SauloAlmeida/api-dotnet-template
```

2. Acesse o diretório
```bash
cd api-dotnet-template/src
```

3. Restaure as dependências:
```bash
dotnet restore
```

## Executar o projeto (Linux)

1. Rode o projeto (modo de desenvolvimento)
```bash
./docker/linux/startup-dev.sh
```

2. Acesse o swagger
```bash
http://localhost:5000/swagger/index.html
```
