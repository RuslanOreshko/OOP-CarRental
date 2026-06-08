# Car Rental System

A console-based car rental management system developed as a course project for Object-Oriented Programming.

## Features

* View all cars
* View available cars
* Search cars by brand
* Rent a car
* Return a car
* Calculate rental prices using pricing strategies
* Save and restore application state using JSON persistence
* Automated testing and CI support

---

## Technologies

* C#
* .NET 9
* xUnit
* GitHub Actions
* JSON Serialization

---

## Architecture

The project follows a layered architecture:

```text
Domain
Application
Infrastructure
Console UI
```

Implemented patterns:

* Repository Pattern
* Strategy Pattern

---

## Project Structure

```text
src/
├── CarRental.Domain
├── CarRental.Application
├── CarRental.Infrastructure
└── CarRental.Console

tests/
└── CarRental.Application.Tests

docs/
```

---

## Running the Application

```bash
dotnet run --project src/CarRental.Console
```

---

## Running Tests

```bash
dotnet test
```

---

## Documentation

Additional documentation is available in:

* USER_GUIDE.md
* DEVELOPER_GUIDE.md
* TESTING.md
* CHANGELOG.md
* FINAL_REPORT.md

Inside the `docs` folder:

* release-plan.md
* performance-analysis.md
* test-strategy.md
* test-matrix.md
* iteration-1.md
* iteration-2.md
* iteration-3.md
* defense-qa.md
* syllabus-coverage.md

---

## Quality Assurance

The project includes:

* Unit Tests
* Integration Tests
* Coverage Collection
* GitHub Actions Continuous Integration

---

## Release

Current version:

```text
v4.0
```

This version represents the final course release.
