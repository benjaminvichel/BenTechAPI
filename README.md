# API BenTech

 Esta API ainda não está finalizada e encontra-se em fase de desenvolvimento!!

A API foi desenvolvida para o projeto **BenTech**. No entanto, a versão atualmente disponível do BenTech não utiliza esta API. Em vez disso, ela está sendo integrada à nova versão do sistema, que ainda está em desenvolvimento.  

# Como baixar e testar a API

## 1. Clonar o repositório
## 2. Configurar a conexão com o banco de dados

A API utiliza **SQL Server**, e a string de conexão está definida em variáveis de ambiente.  
Antes de rodar a aplicação, configure a seguinte variável no sistema:

**Windows (PowerShell)**:
  ```powershell
  $Env:ConnectionStrings__DefaultConnection="Server=<SERVIDOR>;Database=<NOME_DO_BANCO>;User Id=<USUARIO>;Password=<SENHA>;TrustServerCertificate=True;"
```
**Linux/macOS (bash)**:
```powershell
- export ConnectionStrings__DefaultConnection="Server=<SERVIDOR>;Database=<NOME_DO_BANCO>;User Id=<USUARIO>;Password=<SENHA>;TrustServerCertificate=True;"
```

## 3. Restaurar os pacotes NuGet
Dentro da pasta do projeto, execute:
```powershell
dotnet restore
```
## 4.Aplicar as migrations e criar o banco de dados

Caso o banco ainda não tenha sido criado, execute:
```powershell
dotnet ef database update
```
Isso irá criar as tabelas e estruturas necessárias.

## 5. Rodar a API

Para iniciar a API, utilize o comando:
```powershell
dotnet run
```
A API estará disponível em http://localhost:7033.

## 🛠️ Tecnologias Utilizadas  

- **Linguagem:** C# / .NET 8.0
- **Framework:** [FastEndpoints](https://fast-endpoints.com/)  
- **Ferramentas:** Swagger  
