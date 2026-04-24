# TaskTrackerApi

A **production-ready Task Management REST API** built with **ASP.NET Core 9**, **Entity Framework Core**, and **JWT Authentication** — demonstrating clean architecture, service layer abstraction, and real-world backend best practices.

---

## ✨ Features

- 🔐 **JWT Authentication** — secure token-based login & registration
- ✅ **Full Task CRUD** — Create, Read (all + by ID), Update, Delete
- 🎯 **Task Priority Levels** — Low, Medium, High, Critical
- 📅 **Due Dates & Timestamps** — DueDate and CreatedAt tracking per task
- 🔍 **Filtering** — filter tasks by completion status and priority
- 🧩 **Service Layer Architecture** — `IAuthService` / `ITaskService` interfaces with concrete implementations
- 📋 **Input Validation** — Data annotations on all DTOs
- 🗃️ **Fluent API DB Config** — unique index on username, column lengths, FK cascades
- 📝 **Structured Logging** — Serilog with request logging
- 📖 **Swagger / OpenAPI** — interactive docs with JWT auth support

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 9 Web API |
| ORM | Entity Framework Core 9 (Code-First) |
| Database | SQL Server / Azure SQL |
| Auth | JWT Bearer Tokens (HMACSHA512) |
| Logging | Serilog |
| Docs | Swagger (Swashbuckle) |

---

## 📁 Project Structure

```
TaskTrackerApi/
├── Controllers/
│   ├── AuthController.cs       # Register & Login endpoints
│   └── TaskController.cs       # Task CRUD endpoints (JWT-protected)
├── DTOs/
│   ├── LoginDto.cs
│   ├── RegisterDto.cs
│   ├── CreateTaskItemRequest.cs
│   ├── UpdateTaskItemRequest.cs
│   ├── TaskItemDto.cs          # Unified response DTO
│   └── TaskQueryParams.cs      # Filtering parameters
├── Models/
│   ├── User.cs
│   ├── TaskItem.cs
│   └── TaskPriority.cs         # Enum: Low / Medium / High / Critical
├── Services/
│   ├── IAuthService.cs
│   ├── AuthService.cs
│   ├── ITaskService.cs
│   └── TaskService.cs
├── Data/
│   └── AppDbContext.cs         # EF Core context with Fluent API config
├── Migrations/
├── Program.cs
└── appsettings.json
```

---

## 🔗 API Endpoints

| Endpoint | Method | Auth | Description |
|---|---|---|---|
| `/api/auth/register` | POST | No | Register a new user |
| `/api/auth/login` | POST | No | Login and receive JWT token |
| `/api/task` | GET | ✅ JWT | Get all tasks (supports `?isCompleted=true&priority=2` filters) |
| `/api/task/{id}` | GET | ✅ JWT | Get a task by ID |
| `/api/task` | POST | ✅ JWT | Create a new task |
| `/api/task/{id}` | PUT | ✅ JWT | Update a task by ID |
| `/api/task/{id}` | DELETE | ✅ JWT | Delete a task by ID |

### Task Priority Values

| Value | Name |
|---|---|
| 0 | Low |
| 1 | Medium (default) |
| 2 | High |
| 3 | Critical |

---

## 🚀 Setup & Run

### 1. Clone the repository

```bash
git clone https://github.com/BandigariShravan/TaskTrackerApi.git
cd TaskTrackerApi
```

### 2. Configure `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "your_super_secure_key_here_min_32_chars",
    "Issuer": "TaskTrackerAPI",
    "Audience": "TaskTrackerClient"
  }
}
```

### 3. Apply database migrations

```bash
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```

Open Swagger UI: **https://localhost:7071/swagger**

---

## 🔑 Authentication Flow

1. **Register** — `POST /api/auth/register` with `{ "username": "...", "password": "..." }`
2. **Login** — `POST /api/auth/login` to receive a JWT token
3. **Authorize** — In Swagger, click **Authorize** and enter `Bearer <your_token>`
4. **Use protected endpoints** — all `/api/task` routes require the token

---

## 📸 Screenshots

<img width="1768" height="905" alt="image" src="https://github.com/user-attachments/assets/954a3f13-9c76-4e89-9ec4-5283696ebdab" />

<img width="1737" height="916" alt="image" src="https://github.com/user-attachments/assets/80cc5fb9-979c-49cc-aa5e-dd574f20139f" />

<img width="1744" height="915" alt="image" src="https://github.com/user-attachments/assets/cb5a06ef-c8cc-42b8-afdb-c76a762ad9ac" />

<img width="1733" height="906" alt="image" src="https://github.com/user-attachments/assets/ad3eccde-1625-45a8-a88c-ec195c438303" />
