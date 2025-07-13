# TaskTrackerApi

A simple and secure Task Management REST API built with **ASP.NET Core**, **Entity Framework Core**, and **JWT Authentication**.  
Supports user registration, login, and full task CRUD operations. Designed for learning, practice, and portfolio use.

---

##  Features

-  User Registration & Login (JWT-based)
-  Create, Read, Update, Delete (CRUD) Tasks
-  Authentication with JWT Token
-  Role-based task access (user-specific)
-  Swagger API documentation

---

##  Tech Stack

- ASP.NET Core 7 Web API
- Entity Framework Core (Code-First)
- SQL Server / Azure SQL
- JWT Authentication
- Serilog Logging
- Swagger (OpenAPI)

---

##  Project Structure

TaskTrackerApi/
├── Controllers/
├── DTOs/
├── Models/
├── Data/
├── Services/
├── Program.cs
├── appsettings.json


| Endpoint             | Method | Auth | Description             |
|----------------------|--------|------|-------------------------|
| `/api/auth/register` | POST   | NO   | Register new user       |
| `/api/auth/login`    | POST   | NO   | User login, returns JWT |
| `/api/task`          | GET    | YES  | Get all tasks for user  |
| `/api/task`          | POST   | YES  | Create a new task       |
| `/api/task/{id}`     | PUT    | YES  | Update a task by ID     |
| `/api/task/{id}`     | DELETE | YES  | Delete a task by ID     |

---

## 🧰 Setup Instructions

### 1. Clone the repo

git clone https://github.com/BandigariShravan/TaskTrackerApi.git
cd TaskTrackerApi

## Update Configuration
## Update appsettings.json or use a secrets.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskTrackerDb;Trusted_Connection=True;"
},
"Jwt": {
  "Key": "your_super_secure_key_here",
  "Issuer": "TaskTrackerAPI",
  "Audience": "TaskTrackerClient"
}

## 3. Run Migrations

dotnet ef migrations add InitialCreate
dotnet ef database update

## 4. Run the API

dotnet run

Open Swagger UI: https://localhost:7071/swagger


some screenshots for API in postman

<img width="1768" height="905" alt="image" src="https://github.com/user-attachments/assets/954a3f13-9c76-4e89-9ec4-5283696ebdab" />

<img width="1737" height="916" alt="image" src="https://github.com/user-attachments/assets/80cc5fb9-979c-49cc-aa5e-dd574f20139f" />
<img width="1744" height="915" alt="image" src="https://github.com/user-attachments/assets/cb5a06ef-c8cc-42b8-afdb-c76a762ad9ac" />
<img width="1733" height="906" alt="image" src="https://github.com/user-attachments/assets/ad3eccde-1625-45a8-a88c-ec195c438303" />




