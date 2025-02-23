# API BenTech

 Esta API ainda não está finalizada e encontra-se em fase de desenvolvimento!!

A API foi desenvolvida para o projeto **BenTechPatternMVP** que está em fase de desenvolvimento, mas que também está disponível no repositório.

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
**Alteração no program.cs:**

Altere a string "DemoConnection" pela escolhida na etapa anterior!
```powershell
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnection"));
});
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
