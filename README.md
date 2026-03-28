<div align="center" style="display: flex; justify-content: center; gap: 20px;">
    <img src="https://github.com/user-attachments/assets/78c74655-d85d-483d-afd6-faca885a1c0a" width="1000px">
</div>

# BenTech API

A dedicated internal API built to power the **BenTech Hotel Daily Rate Calculator**, handling all communication between the frontend, business logic, and the SQL Server database in a structured and scalable way.

## How to Run Locally

### 1. Clone the repository

### 2. Configure the database connection

The API uses **SQL Server**. Set the connection string as an environment variable before running:

**Windows (PowerShell):**
```powershell
$Env:ConnectionStrings__DefaultConnection="Server=<SERVER>;Database=<DATABASE>;User Id=<USER>;Password=<PASSWORD>;TrustServerCertificate=True;"
```

**Linux/macOS (bash):**
```bash
export ConnectionStrings__DefaultConnection="Server=<SERVER>;Database=<DATABASE>;User Id=<USER>;Password=<PASSWORD>;TrustServerCertificate=True;"
```

Then update `program.cs` to match the connection string name you defined:
```csharp
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
```

### 3. Restore NuGet packages
```powershell
dotnet restore
```

### 4. Apply migrations
```powershell
dotnet ef database update
```

### 5. Run the API
```powershell
dotnet run
```

The API will be available at http://localhost:7033.

## Tech Stack

- **Language:** C# / .NET 8.0
- **Framework:** FastEndpoints
- **Tools:** Swagger
```
