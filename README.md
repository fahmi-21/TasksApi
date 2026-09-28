# Tasks API

A simple RESTful API for managing tasks, built with ASP.NET Core, Entity Framework Core, SQL Server, Generic Repository Pattern, and FluentValidation.

## Technologies

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* FluentValidation
* Generic Repository Pattern
* Dependency Injection
* RESTful API
* Server-side Pagination

## Features

* Create a task
* Get all tasks with pagination
* Get a task by ID
* Update a task
* Delete a task
* Request validation using FluentValidation
* Entity Framework Core with SQL Server
* Generic Repository Pattern
* Dependency Injection

## API Endpoints

| Method | Endpoint                  | Description         |
| ------ | ------------------------- | ------------------- |
| POST   | `/api/Tasks/Create`       | Create a new task   |
| GET    | `/api/Tasks/GetAll`       | Get paginated tasks |
| GET    | `/api/Tasks/GetById/{id}` | Get a task by ID    |
| PUT    | `/api/Tasks/Update/{id}`  | Update a task       |
| DELETE | `/api/Tasks/Delete/{id}`  | Delete a task       |

## Task Model

A task contains the following properties:

```json
{
  "id": 1,
  "title": "Learn ASP.NET Core",
  "description": "Study REST API and Entity Framework Core",
  "isCompleted": false
}
```

## API Usage

### 1. Create Task

**POST**

```text
/api/Tasks/Create
```

Request body:

```json
{
  "title": "Learn ASP.NET Core",
  "description": "Study REST API"
}
```

---

### 2. Get All Tasks

**GET**

```text
/api/Tasks/GetAll?page=1&pageSize=5
```

The API supports server-side pagination using `page` and `pageSize`.

Example:

```text
page=1
pageSize=5
```

returns the first 5 tasks.

---

### 3. Get Task By ID

**GET**

```text
/api/Tasks/GetById/1
```

The `1` represents the task ID.

If the task does not exist, the API returns:

```text
404 Not Found
```

---

### 4. Update Task

**PUT**

```text
/api/Tasks/Update/1
```

Request body:

```json
{
  "title": "Learn ASP.NET Core Web API",
  "description": "Study REST API, EF Core and FluentValidation",
  "isCompleted": true
}
```

---

### 5. Delete Task

**DELETE**

```text
/api/Tasks/Delete/1
```

The `1` represents the task ID.

A successful deletion returns:

```text
204 No Content
```

## Validation

The API uses FluentValidation to validate incoming requests.

Examples of validation rules:

* Title is required.
* Title must contain at least 3 characters.
* Title cannot exceed 100 characters.
* Description cannot exceed 500 characters.

## Project Structure

```text
Tasks API
│
├── Controllers
├── DataAccess
├── DTOs
├── Model
├── Repositories
├── Services
├── Validators
├── Migrations
│
├── Program.cs
├── appsettings.json
└── README.md
```

## Database

The project uses:

* SQL Server
* Entity Framework Core
* Code First approach
* EF Core Migrations

to make migration 
```bash

dotnet ef migrations initialcreate
```


To apply the database migrations:
```bash

dotnet ef database update
```

