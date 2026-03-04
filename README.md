# 🔗 URL Shortener API

> A RESTful API built with ASP.NET Core to simulate a URL shortening service (similar to Bit.ly). 

I developed this side project to strengthen my backend development skills, practice modern API architecture, and understand how to manage in-memory data efficiently.

## 📝 What I Learned & Implemented

* **RESTful Architecture:** Applied standard REST principles, ensuring the API returns appropriate HTTP status codes like `201 Created` (instead of a basic 200 OK) and `302 Found` for redirections.
* **Dependency Injection (DI):** Separated the core business logic from the controllers by utilizing interfaces (`IUrlShortenerService`), making the application more modular and testable.
* **Data Transfer Objects (DTO):** Used DTOs (`ShortenRequestDto`, `ShortenResponseDto`) to securely manage the data flowing in and out of the API.
* **Thread-Safe Data Structures:** Instead of a standard Dictionary, I researched and implemented a `ConcurrentDictionary` to safely handle simultaneous requests without data corruption.

## 🛠️ Tech Stack

* **Framework:** .NET / ASP.NET Core Web API
* **Language:** C#
* **Concepts:** REST API, Dependency Injection, DTO Pattern

## 📡 API Endpoints

| Method | Endpoint | Body/Params | Description | Success Response |
| :--- | :--- | :--- | :--- | :--- |
| `POST` | `/api/url/shorten` | `{ "OriginalUrl": "https://..." }` | Generates a unique 6-character short code for the provided URL. | `201 Created` |
| `GET`  | `/api/url/{shortCode}` | `shortCode` (in URL path) | Redirects the user to the original long URL. | `302 Found` |

## ⚙️ How to Run Locally

1. Clone the repository:
   ```bash
   git clone [https://github.com/Tobacconist/UrlShortener-API.git](https://github.com/Tobacconist/UrlShortener-API.git)
2. Open the .sln file in Visual Studio.

3. Press F5 or click Run to start the IIS Express / Kestrel server.

4. Use the built-in Swagger interface or Postman to test the endpoints.
