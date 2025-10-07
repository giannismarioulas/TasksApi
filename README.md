# 🗂️ Tasks API

A simple RESTful API built with **.NET 8** and **Entity Framework Core**, designed to manage task items with full CRUD operations.
The project demonstrates modern API design, PostgreSQL integration, and clean deployment readiness.

---

## ⚙️ Tech Stack

* **.NET 8 / ASP.NET Core Minimal API**
* **Entity Framework Core** (EF)
* **PostgreSQL**
* **Swagger / OpenAPI** for documentation

---

## 🧩 Project Structure

```
TasksApi/
│
├── Data/
│   └── TasksDbContext.cs
│
├── Models/
│   └── TaskItem.cs
│
├── Program.cs
└── appsettings.json
```

---

## 🧾 Endpoints

| Method | Endpoint      | Description             |
| :----- | :------------ | :---------------------- |
| GET    | `/tasks`      | Get all tasks           |
| GET    | `/tasks/{id}` | Get a task by ID        |
| POST   | `/tasks`      | Create a new task       |
| PUT    | `/tasks/{id}` | Update an existing task |
| DELETE | `/tasks/{id}` | Delete a task           |

---

## 💻 Local Setup

### 1. Clone the Repository

```bash
git clone https://github.com/giannismarioulas/TasksApi.git
cd TasksApi
```

### 2. Configure PostgreSQL

Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=tasksdb;Username=postgres;Password=yourpassword"
}
```

### 3. Run EF Migrations

```bash
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```

Then open [http://localhost:5279/swagger](http://localhost:5279/swagger) in your browser.

---

## 🚀 Deployment

The API is ready for deployment on platforms such as **Render**, **Railway**, or **Azure App Service**.
During deployment, ensure the following environment variable is set:

```
ConnectionStrings__DefaultConnection=<your_production_connection_string>
```

---

## 👨‍💻 Author

Developed by **Giannis Marioulas**

GitHub: [@giannismarioulas](https://github.com/giannismarioulas)
