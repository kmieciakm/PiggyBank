## 🐷 PiggyBank

### 🚀 Overview
A lightweight Blazor app for expense tracking.

---

## ⚙️ Prerequisites

- .NET SDK 10.0
- Docker Desktop (with Compose support)
- Git (recommended)
- VS Code / Visual Studio 2026 with C# tooling

---

## 💻 Local development guide

### 1. Run database with Docker

- Prepare `.env` for Docker secrets (in root or `src/` as used by your compose file):
  ```env
  # .env
  POSTGRES_PASSWORD=your_password
  PGADMIN_DEFAULT_PASSWORD=your_password
  ```

- Start containers:
  ```bash
  docker-compose -p piggybank up -d
  ```

---

### 2. Configure Application

- Add User Secrets in Visual Studio
  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=piggybank;Username=your_password;Password=your_password"
    }
  }
  ```

- (alternatively) Set User Secrets via Terminal 
  
  From project root:
  ```bash
  cd src/PiggyBank.Web
  dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=piggybank;Username=your_password;Password=your_password"
  ```

---

### 3. Run Application

- Via Visual Studio:

  Set `PiggyBank.Web` as startup project and run (`F5`)

- (alternatively) Via Command Line:
  ```bash
  cd src/PiggyBank.Web
  dotnet run
  ```