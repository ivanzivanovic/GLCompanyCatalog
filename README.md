# GL Company Catalog Solution
GL Company Catalog Solution — A .NET-based system for managing a catalog of companies that a client works with. Includes a REST API, Blazor frontend, user authentication with ASP.NET Core Identity, and Docker support.

## Features

- Fully containerized solution using Docker and Docker Compose  
- Out-of-the-box setup with a single command  
- ASP.NET Core Web API with Identity-based authentication  
- Blazor WASM WebApp frontend  
- SQL Server database running in a container with persisted data  
- Swagger UI available for API documentation and testing  
- Integration and unit tests included
- Implements **Clean Architecture** principles for clear separation of concerns  
- Uses **CQRS (Command Query Responsibility Segregation)** pattern to organize business logic

# GL Company catalog solution description

``` 
GL.CompanyCatalog.sln
│
├─ src/
│  ├─ API/
│  │   └─ GL.CompanyCatalog.Api\GL.CompanyCatalog.Api.csproj
│  ├─ Core/
│  │   └─ GL.CompanyCatalog.Domain\GL.CompanyCatalog.Domain.csproj
│  │   └─ GL.CompanyCatalog.Application\GL.CompanyCatalog.Application.csproj
│  ├─ Infrastructure/
│  │   ├─ GL.CompanyCatalog.Infrastructure\GL.CompanyCatalog.Infrastructure.csproj
│  │   └─ GL.CompanyCatalog.Persistence\GL.CompanyCatalog.Persistence.csproj
│  │   └─ GL.CompanyCatalog.Identity\GL.CompanyCatalog.Identity.csproj
│  └─ UI/
│      └─ GL.CompanyCatalog.WebApp\GL.CompanyCatalog.WebApp.csproj
├─ build/
│  └─ docker-compose.yml
├─ test/
   ├─ GL.CompanyCatalog.API.IntegrationTests\GL.CompanyCatalog.API.IntegrationTests.csproj
   ├─ GL.CompanyCatalog.Application.UnitTests\GL.CompanyCatalog.Application.UnitTests.csproj
   └─ GL.CompanyCatalog.Persistence.IntegrationTests\GL.CompanyCatalog.Persistence.IntegrationTests.csproj
 ```   
## Detailed Projects Description

### GL.CompanyCatalog.Domain  
Contains the core business entities, currently two entities: Company and Category. GL.CompanyCatalog.Domain is independent from other layers. The Company entity holds key information such as company name, exchange, ticker, ISIN code, and website.

### GL.CompanyCatalog.Application  
The GL.CompanyCatalog.Application project represents the application layer within the Clean Architecture structure of the GL Company catalog solution. Its main role is to orchestrate business logic, implement CQRS handlers, validation, mapping, and communication with other layers (Domain, Infrastructure).

- ✅ Contains Command Handlers and Query Handlers that separate write operations (Commands) and read operations (Queries), applying the CQRS pattern.
- ✅ Handlers are registered and executed using the MediatR library, which acts as a mediator between layers and facilitates decoupling.
- ✅ Applies validation within handlers using FluentValidation.
- ✅ Uses AutoMapper for mapping DTO objects to domain entities and vice versa.
- ✅ Uses the Repository Pattern via the IAsyncRepository<T> interface, allowing database interaction in an abstract and testable way.
- ✅ The layer communicates with external services through interfaces (e.g., IAsyncRepository, IEmailService, IECsbExporter).
- ✅ ILogger is implemented for logging errors and key events.

### GL.CompanyCatalog.Infrastructure  
This project contains the implementation of infrastructure services for sending emails and exporting in CSV format. SendGrid is used for sending emails, and CsvHelper library is used for CSV export.

### GL.CompanyCatalog.Persistance  
Entity Framework Core Code First for working with the database. Uses Windows Authentication for SQL Server.

### GL.CompanyCatalog.Identity  
Authentication in the Glass Lewis Company Management system is based on the ASP.NET Core Identity framework, which enables user management, login, and authorization. User data is stored in a separate SQL Server database using Entity Framework Core via the DbContext. Authentication uses a cookie-based approach, where user data is stored in cookies after successful login. The system supports defining access rules through a built-in authorization mechanism. API endpoints for standard identity operations such as registration, login, and logout are also integrated.

### GL.CompanyCatalog.Api  
REST API exposing endpoints for company management. Swagger/OpenAPI documentation.  
✅ Exception handling in GL.CompanyCatalog.Api is implemented via custom middleware (ExceptionHandlerMiddleware). All exceptions are caught globally and returned as JSON responses with appropriate HTTP status codes. It supports ValidationException, BadRequestException, NotFoundException, and other exceptions. The middleware is registered in the pipeline via UseCustomExceptionHandler(), providing a unified, centralized error handling approach throughout the API.

### GL.CompanyCatalog.WebApp  
In development: Blazor WASM single page application.

### Testing Projects  
Automated unit and integration tests are implemented as xUnit projects. Tests run against mocked InMemory databases. Integration tests for API and Persistance projects use the Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory library to generate API clients. Moq and Shouldly libraries are used.

# Running the Solution

## Prerequisites

- [Docker](https://docs.docker.com/get-docker/) and [Docker Compose](https://docs.docker.com/compose/install/) installed  
- Optional: [.NET SDK](https://dotnet.microsoft.com/en-us/download) for local development without Docker  

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/ivanzivanovic/GLCompanyCatalog.git
   cd GL.CompanyCatalog
   
2. Build and start all containers using Docker Compose:
   ```bash
   docker-compose up --build

3. Wait until all containers are up and running.

4. Access the API at:
   http://localhost:7081

5. Access the Web UI (Blazor app) at:
   http://localhost:7080
   
7. Access Swagger UI for API documentation and testing at:
   http://localhost:7081/swagger

8. To stop and remove containers when finished:
   ```bash
   docker-compose down
   
9. To view logs of running containers:
   ```bash    
   docker-compose logs

## Tests
This solution includes unit and integration tests to verify business logic, data persistence, and API endpoints.

> **Note:** These tests are provided as **examples only** and do **not cover all scenarios**. The current test coverage is not sufficient for production-grade validation.  
> It is highly recommended to add more tests to cover edge cases, failure scenarios, and business rules.

### Test projects
1. GL.CompanyCatalog.API.IntegrationTests — verifies API endpoints with a test server.
2. GL.CompanyCatalog.Application.UnitTests — tests CQRS handlers and business rules.
3. GL.CompanyCatalog.Persistence.IntegrationTests — tests database context behavior and auditing.

### Running tests locally

Option 1: Using Visual Studio

1. Open the solution GL.CompanyCatalog.sln in Visual Studio.
2. Open the Test Explorer (Test → Test Explorer).
3. Click Run All Tests or run individual tests.
4. Inspect results directly in Visual Studio.

Option 2: Using .NET CLI
From the solution root folder, run:
```bash    
dotnet test

