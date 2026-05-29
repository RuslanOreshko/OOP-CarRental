# TESTING

## Overview

This project uses automated testing to verify the correctness of the Car Rental System.

Testing is divided into two categories:

- Unit Tests
- Integration Tests

## Running All Tests

Run all tests:

```bash
dotnet test
```

## Running Specific Test Project

```bash
dotnet test tests/CarRental.Application.Tests
```

## Unit Test Coverage

Unit tests verify:

### Domain Layer

- Car state transitions
- Rental creation rules

### Application Layer

- RentalCarService
- Pricing strategies
- Business validation

### Extension Methods

- GetAvailableCars()
- GetCarsByBrand()
- GetAveragePrice()

### Negative Scenarios

- Car not found
- Rental not found
- Renting unavailable car
- Invalid operations

## Integration Test Coverage

Integration tests verify:

### Persistence

- Saving data to JSON
- Loading data from JSON
- Data restoration after restart

### Business Workflows

- Rent → Save → Reload
- Return → Save → Reload

### Fault Handling

- Missing file
- Corrupted file
- Multiple save operations

## Test Structure

```text
tests/
└── CarRental.Application.Tests
    ├── Services
    ├── Pricing
    ├── Extensions
    ├── Persistence
    └── Domain
```

## Quality Goals

The testing strategy focuses on:

- Business logic correctness
- Protection against regressions
- Persistence reliability
- Fault tolerance
- Maintainability

## CI Verification

All tests are executed automatically through GitHub Actions during pull request validation and continuous integration builds.
