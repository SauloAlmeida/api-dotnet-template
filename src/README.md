# dotnet api template

## Requisitos

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* [Docker](https://docs.docker.com/desktop/install/windows-install/)

## Instala��o

1. Clone o projeto	
```bash
https://github.com/SauloAlmeida/api-dotnet-template
```

2. Acesse o diret�rio
```bash
cd api-dotnet-template/src
```

3. Restaure as depend�ncias:
```bash
dotnet restore
```

## Rodar o projeto

1. Rode o projeto
```bash
dotnet run --project api
```

2. Veja a rota informada
```bash
[00:00:01 INF] Now listening on: http://localhost:xxxx
```

3. Acesse o swagger
```bash
http://localhost:xxxx/swagger
```