# WebApi Teste para desenvolvedor backend

WEBAPI feito com dotnet 8 para teste da empresa GOL

## Como executar o projeto local

### Variáveis de ambiente

Ajustar as variáveis de ambiente `ASPNETCORE_ENVIRONMENT` e `DOTNET_ENVIRONMENT` com o valor `Development` no sistema operacional.

No Windows, para criar a variável de ambiente para o usuário conectado, ou alterar o valor, com CMD:

```bash
setx ASPNETCORE_ENVIRONMENT "Development"
setx DOTNET_ENVIRONMENT "Development"
```

No MacOS, para criar as variáveis de ambiente permanentemente, é necessário editar o arquivo `~/.bash_profile` como root e acrescentar as seguintes linhas no final do arquivo:

```bash
export ASPNETCORE_ENVIRONMENT="Development"
export DOTNET_ENVIRONMENT="Development"
```

**Obs**: Inseridas as linhas, reinicie o terminal para que as variáveis fiquem disponíveis no ambiente

### Utilizando dotnet user-secrets

- Necessário habilitar o user-secrets e adicionar as seguintes chaves:

    ```bash
    dotnet user-secrets init --project src/Gol.WebApi/
    dotnet user-secrets set "ConnectionString:Identity" "Server=<<Server>>;Database=<<Database>>;User Id=<<User>>;Password=<<Password>>;" --project src/Gol.WebApi/
    dotnet user-secrets set "Firebase:ApiKey" "<<String Aleatória>>" --project src/Gol.WebApi/
  ```
  
### Utilizando Migrations no projeto

- Necessário instalar o pacote do EntityFramework Core Tools:

  ```bash
  dotnet tool install --global dotnet-ef
  ```

- Para criar as migrations, é necessário executar o seguinte comando:
  ```bash
  dotnet ef migrations add [Name_Migration] --startup-project src/Gol.WebApi --project src/Gol.Infrastructure
  ```
    
- Para executar as migrations, é necessário executar o seguinte comando:

  ```bash
  dotnet ef database update --startup-project src/Gol.WebApi --project src/Gol.Infrastructure 
  ```

### Ferramentas necessárias

- Docker/Docker Compose
- Instância local do SQL Server (pode ser o SQLocalDB que vem com Visual Studio)

### Utilizando o Docker Compose

- Garantir que a instância do banco de dados SQLServer está disponível.

  - É possível utilizar o `docker-compose.yml` disponível na Solution para subir um container do SQL Server.

  ``` bash
  docker-compose up -d
  ```

- Garantir que os projetos estão compilando:

  - Restaurar os pacotes:

  ``` bash
  dotnet restore
  ```

  - Executar o build:

  ``` bash
  dotnet build
  ```

- Prepara a base de dados:

  - Para o projeto da WebApi é necessário executar as migrations para a criação dos objetos no banco de dados.

    ```bash
    dotnet ef database update 
    ```

- Executar o projeto `src/Gol.WebApi`. Ao executar pelo Visual Studio o navegador padrão será aberto na página do Swagger.

  - Executar por linha de comando:

    ```bash
    dotnet run -p src/Gol.WebApi
    ```

## Características do projeto

- .NET 8
- Banco de dados SQL Server
- ORM: **EntityFramework Core**
