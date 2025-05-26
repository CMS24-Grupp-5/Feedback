# 🗣️ Feedback Microservice

A lightweight .NET microservice for managing user feedback in distributed systems. Supports full CRUD operations via RESTful endpoints, backed by EF Core and a relational database.

## 🧩 Tech Stack

* .NET 8 / C#
* ASP.NET Core Web API
* Entity Framework Core
* xUnit (unit testing)

## 🗃️ Model

```csharp
public class Feedback
{
    public string Id { get; set; }
    public string Author { get; set; }
    public string FeedbackText { get; set; }
}
````

## 🚀 API Endpoints

### `GET /api/feedbacks`

Returns all feedback entries.

### `GET /api/feedbacks/{id}`

Returns a single feedback entry by ID.

### `POST /api/feedbacks`

Creates a new feedback entry.

### `PUT /api/feedbacks`

Updates an existing feedback entry.

### `DELETE /api/feedbacks/{id}`

Deletes the feedback entry with the specified ID.
