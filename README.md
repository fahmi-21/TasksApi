# Tasks API

A simple and clean RESTful Web API for managing tasks, built with **ASP.NET Core**, **Entity Framework Core**, and **SQL Server**.

The project demonstrates a structured backend implementation with **Generic Repository Pattern**, **Dependency Injection**, **FluentValidation**, **DTOs**, and **server-side pagination**.

---

## 📌 Project Overview

Tasks API provides a set of RESTful endpoints for creating, retrieving, updating, and deleting tasks.

Each task contains:

* `Id`
* `Title`
* `Description`
* `IsCompleted`

The API also supports server-side pagination when retrieving tasks.

---

## 🚀 Features

* Create a new task
* Get all tasks
* Get a task by ID
* Update an existing task
* Delete a task
* Server-side pagination
* Request validation using FluentValidation
* Entity Framework Core with SQL Server
* Code First approach
* EF Core Migrations
* Generic Repository Pattern
* Service Layer
* Dependency Injection
* DTO-based requests
* Proper HTTP status codes
* Postman Collection for API testing

---

## 🛠️ Technologies

| Technology                 | Usage                   |
| -------------------------- | ----------------------- |
| C#                         | Programming language    |
| ASP.NET Core Web API       | API development         |
| Entity Framework Core      | ORM / Data access       |
| SQL Server                 | Database                |
| FluentValidation           | Request validation      |
| Generic Repository Pattern | Data access abstraction |
| Dependency Injection       | Dependency management   |
| Postman                    | API testing             |
| Git & GitHub               | Version control         |

---

# 🏗️ Architecture

The project follows a layered backend structure:

```text
Controller
    ↓
Service
    ↓
Generic Repository
    ↓
AppDbContext
    ↓
SQL Server
```

### Controller Layer

Responsible for:

* Receiving HTTP requests
* Calling the appropriate service
* Returning HTTP responses

### Service Layer

Contains the application/business logic and communicates with the repository.

### Repository Layer

Provides a reusable abstraction for database operations using the Generic Repository Pattern.

### Data Access Layer

Contains `AppDbContext` and Entity Framework Core configuration.

---

# 📂 Project Structure

```text
Tasks API
│
├── Controllers
│   └── TasksController.cs
│
├── DataAccess
│   └── AppDbContext.cs
│
├── DTOs
│   ├── Requests
│   │   ├── CreatTaskRequest.cs
│   │   └── UpdateTaskRequest.cs
│   │
│   └── Responses
│       └── TaskResponse.cs
│
├── Model
│   └── Task.cs
│
├── Repositories
│   ├── IRepository.cs
│   └── Repository.cs
│
├── Services
│   ├── IService
│   │   └── ITaskServcie.cs
│   │
│   └── TaskService.cs
│
├── Validators
│   ├── CreateTaskValidator.cs
│   └── UpdateTaskValidator.cs
│
├── Migrations
│
├── Program.cs
├── appsettings.json
├── GlobalUsings.cs
└── README.md
```

---

# 🌐 API Information

## Base URL

During local development:

```text
http://localhost:5107
```

> The port may be different depending on the local launch configuration.

---

# 📋 Task Model

A task contains the following properties:

| Property      | Type     | Description                             |
| ------------- | -------- | --------------------------------------- |
| `Id`          | `int`    | Unique task identifier                  |
| `Title`       | `string` | Task title                              |
| `Description` | `string` | Task description                        |
| `IsCompleted` | `bool`   | Indicates whether the task is completed |

Example:

```json
{
  "id": 1,
  "title": "Learn ASP.NET Core",
  "description": "Study REST API and Entity Framework Core",
  "isCompleted": false
}
```

---

# 🔗 API Endpoints

| Method   | Endpoint                  | Description                   |
| -------- | ------------------------- | ----------------------------- |
| `POST`   | `/api/Tasks/Create`       | Create a new task             |
| `GET`    | `/api/Tasks/GetAll`       | Get all tasks with pagination |
| `GET`    | `/api/Tasks/GetById/{id}` | Get a task by ID              |
| `PUT`    | `/api/Tasks/Update/{id}`  | Update a task                 |
| `DELETE` | `/api/Tasks/Delete/{id}`  | Delete a task                 |

---

# 1️⃣ Create Task

Creates a new task.

### Request

```http
POST /api/Tasks/Create
```

### Request Body

```json
{
  "title": "Learn ASP.NET Core",
  "description": "Study REST API and Entity Framework Core"
}
```

### Success Response

**200 OK**

```json
{
  "id": 1,
  "title": "Learn ASP.NET Core",
  "description": "Study REST API and Entity Framework Core",
  "isCompleted": false
}
```

The `IsCompleted` property is initialized to `false` when a task is created.

---

# 2️⃣ Get All Tasks

Returns a paginated list of tasks.

### Request

```http
GET /api/Tasks/GetAll?page=1&pageSize=5
```

### Query Parameters

| Parameter  | Type  | Default | Description              |
| ---------- | ----- | ------: | ------------------------ |
| `page`     | `int` |     `1` | Page number              |
| `pageSize` | `int` |     `5` | Number of tasks per page |

### Example

```text
GET /api/Tasks/GetAll?page=1&pageSize=5
```

### Response

**200 OK**

```json
{
  "tasks": [
    {
      "id": 1,
      "title": "Learn ASP.NET Core",
      "description": "Study REST API",
      "isCompleted": false
    },
    {
      "id": 2,
      "title": "Practice EF Core",
      "description": "Work with migrations",
      "isCompleted": true
    }
  ],
  "totalPages": 2,
  "currentPage": 1
}
```

### Pagination Behavior

The API accepts the requested page and page size from the client.

For example:

```text
page=1&pageSize=5
```

returns the first 5 tasks.

```text
page=2&pageSize=5
```

returns the next 5 tasks.

---

# 3️⃣ Get Task By ID

Returns a specific task using its ID.

### Request

```http
GET /api/Tasks/GetById/1
```

### Success Response

**200 OK**

```json
{
  "id": 1,
  "title": "Learn ASP.NET Core",
  "description": "Study REST API",
  "isCompleted": false
}
```

### Task Not Found

**404 Not Found**

```json
{
  "message": "Task is not found"
}
```

---

# 4️⃣ Update Task

Updates an existing task.

### Request

```http
PUT /api/Tasks/Update/1
```

The `1` represents the task ID.

### Request Body

```json
{
  "title": "Learn ASP.NET Core Web API",
  "description": "Study REST API, EF Core and FluentValidation",
  "isCompleted": true
}
```

### Success Response

**200 OK**

```json
{
  "id": 1,
  "title": "Learn ASP.NET Core Web API",
  "description": "Study REST API, EF Core and FluentValidation",
  "isCompleted": true
}
```

### Task Not Found

**404 Not Found**

```json
{
  "message": "Task is not found"
}
```

---

# 5️⃣ Delete Task

Deletes an existing task.

### Request

```http
DELETE /api/Tasks/Delete/1
```

### Success Response

**204 No Content**

A successful delete does not return a response body.

### Task Not Found

**404 Not Found**

```json
{
  "message": "Task is not found"
}
```

---

# ✅ Validation

The API uses **FluentValidation** to validate incoming requests.

## Create Task Validation

| Field         | Validation             |
| ------------- | ---------------------- |
| `Title`       | Required               |
| `Title`       | Minimum 3 characters   |
| `Title`       | Maximum 100 characters |
| `Description` | Maximum 500 characters |

## Update Task Validation

| Field         | Validation             |
| ------------- | ---------------------- |
| `Title`       | Required               |
| `Title`       | Minimum 3 characters   |
| `Title`       | Maximum 100 characters |
| `Description` | Maximum 500 characters |

Example of an invalid request:

```json
{
  "title": "",
  "description": "Invalid task"
}
```

The API returns a validation error response.

---

# 📡 HTTP Status Codes

The API uses standard HTTP status codes:

| Status Code                 | Meaning                             |
| --------------------------- | ----------------------------------- |
| `200 OK`                    | Request completed successfully      |
| `204 No Content`            | Resource deleted successfully       |
| `400 Bad Request`           | Invalid request or validation error |
| `404 Not Found`             | Requested task does not exist       |
| `500 Internal Server Error` | Unexpected server-side error        |

---

# 🗄️ Database

The project uses:

* SQL Server
* Entity Framework Core
* Code First approach
* EF Core Migrations

The database schema is managed through Entity Framework Core migrations.

### Apply Migrations

Run:

```bash
dotnet ef database update
```

---

# ⚙️ Configuration

Update the connection string in `appsettings.json` according to your local SQL Server configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
}
```

> Do not commit sensitive credentials or environment-specific secrets to the repository.

---

# ▶️ How to Run

## 1. Clone the Repository

```bash
git clone YOUR_GITHUB_REPOSITORY_URL
```

## 2. Open the Project

Open the solution in Visual Studio or your preferred .NET IDE.

## 3. Configure the Database

Update the `DefaultConnection` connection string.

## 4. Apply Migrations

```bash
dotnet ef database update
```

## 5. Run the API

```bash
dotnet run
```

The API will be available at the configured local URL.

---

# 🧪 Postman Collection

A complete **Postman Collection** is included in the repository.

Location:

```text
Postman/
└── Tasks API.postman_collection.json
```

The collection contains all available endpoints:

* Create Task
* Get All Tasks
* Get Task By ID
* Update Task
* Delete Task

### Import Collection

1. Open Postman.
2. Click **Import**.
3. Select `Tasks API.postman_collection.json`.
4. Run the requests to test the API.

---

# 🧪 API Testing

All API endpoints were tested using Postman, including:

* Successful task creation
* Retrieving all tasks
* Retrieving a task by ID
* Updating an existing task
* Deleting a task
* Handling non-existing task IDs
* Request validation

---

# 📌 Design Patterns & Practices

The project applies several backend development practices:

### Generic Repository Pattern

Provides reusable data access operations for entities.

### Service Layer

Keeps business/application logic separate from controllers.

### Dependency Injection

Dependencies are injected through constructors and registered in the ASP.NET Core DI container.

### DTOs

Request and response models are used to separate API contracts from the persistence model.

### FluentValidation

Provides clear and maintainable validation rules for incoming requests.

### Server-Side Pagination

Pagination parameters are received from the client so the API can return a specific page and page size.

---

# 📄 API Documentation

This README provides an overview of the API endpoints, request formats, response examples, validation rules, and setup instructions.

For interactive API testing, use the included Postman Collection.


