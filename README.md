# PaginationFlow – ASP.NET Core MVC Pagination Architecture

## 📌 Overview

**PaginationFlow** is a clean and scalable implementation of **server-side pagination** in an ASP.NET Core MVC application.  
The project follows **Layered Architecture** with the **Repository Pattern** and **Service Layer**, ensuring separation of concerns, maintainability, and testability.

This implementation focuses **only on pagination** (no search or filtering), making it easy to extend later.

---

## 🏗 Architecture Overview

```

Controller
↓
Service Layer
↓
Repository Layer
↓
Database (Entity Framework Core)

```

---

## 📂 Project Structure

```

PaginationFlow
│
├── Controllers
│   └── ProductController.cs
│
├── Services
│   └── ProductService.cs
│
├── Repository
│   ├── IRepository
│   │   └── IRepository.cs
│   └── Repository.cs
│
├── Pagination
│   └── PagedResult.cs
│
├── Data
│   └── ApplicationDbContext.cs

````

---

## 🔁 Pagination Flow

1. User requests a page (e.g. `/Product/Index?page=2`)
2. Controller sends `page` and `pageSize` to the service
3. Service calls repository pagination method
4. Repository applies `Skip()` and `Take()` using LINQ
5. Data is returned as a `PagedResult<T>`
6. View renders paginated results

---

## 📦 Core Components

### Controller

```csharp
public IActionResult Index(int page = 1)
{
    int pageSize = 10;
    var products = _productService.GetPagedProducts(page, pageSize);
    return View(products);
}
````

---

### Service Layer

```csharp
public PagedResult<Product> GetPagedProducts(int page, int pageSize)
{
    return _repository.GetPaged(page, pageSize);
}
```

---

### Repository Interface

```csharp
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    PagedResult<T> GetPaged(int pageNumber, int pageSize);
    T? GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
}
```

---

### Repository Pagination Logic

```csharp
public PagedResult<T> GetPaged(int pageNumber, int pageSize)
{
    int totalItems = _dbSet.Count();

    var items = _dbSet
        .AsNoTracking()
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return new PagedResult<T>
    {
        Items = items,
        TotalItems = totalItems,
        PageNumber = pageNumber,
        PageSize = pageSize
    };
}
```

---

### Pagination Model

```csharp
public class PagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public int TotalPages =>
        (int)Math.Ceiling((double)TotalItems / PageSize);
}
```

---

## ⚙ Technologies Used

* ASP.NET Core MVC
* .NET 8
* Entity Framework Core
* LINQ
* Repository Pattern
* Service Layer Pattern

---

## ✅ Features

* Server-side pagination
* Clean layered architecture
* Generic repository support
* Optimized database queries
* Easy to extend and maintain

---

## 🚀 Future Improvements

* Search with pagination
* Sorting support
* AJAX pagination
* Unit testing (xUnit, Moq)
* Caching for large datasets

---

## 👤 Author

**Rifatul Islam**
ASP.NET Core Developer
Focused on clean architecture and scalable solutions
