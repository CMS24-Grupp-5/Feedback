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

---

### `GET /api/feedbacks`

Returns all feedback entries.

**Response:**

```json
[
  {
    "id": "1",
    "author": "Alice",
    "feedbackText": "Great platform!"
  },
  {
    "id": "2",
    "author": "Bob",
    "feedbackText": "Needs more features."
  }
]
```

---

### `GET /api/feedbacks/{id}`

Returns a single feedback entry by ID.

**Response:**

```json
{
  "id": "1",
  "author": "Alice",
  "feedbackText": "Great platform!"
}
```

**Status Codes:**

* `200 OK` – Feedback found
* `404 Not Found` – Feedback not found

---

### `POST /api/feedbacks`

Creates a new feedback entry.

**Request:**

```json
{
  "author": "Charlie",
  "feedbackText": "Really helpful app!"
}
```

**Response:**

```json
{
  "id": "3",
  "author": "Charlie",
  "feedbackText": "Really helpful app!"
}
```

**Status Codes:**

* `201 Created`
* `400 Bad Request` – Validation failure

---

### `PUT /api/feedbacks`

Updates an existing feedback entry.

**Request:**

```json
{
  "id": "2",
  "author": "Bob",
  "feedbackText": "Updated feedback after the new release."
}
```

**Response:**

```json
{
  "id": "2",
  "author": "Bob",
  "feedbackText": "Updated feedback after the new release."
}
```

**Status Codes:**

* `200 OK` – Successfully updated
* `404 Not Found` – Feedback not found

---

### `DELETE /api/feedbacks/{id}`

Deletes the feedback entry with the specified ID.

**Response:**

* `204 No Content` – Successfully deleted
* `404 Not Found` – Feedback not found
