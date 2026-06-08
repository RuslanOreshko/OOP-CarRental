# Developer Guide

## Architecture

The project follows a layered architecture:

* Domain
* Application
* Infrastructure
* Console UI

## Main Components

### Domain

Contains business entities:

* Car
* Customer
* Rental

### Application

Contains:

* Services
* DTOs
* Extension Methods
* Pricing Strategies

### Infrastructure

Contains:

* Repositories
* JSON Persistence
* Data Seeding

### Console UI

Contains menu navigation and user interaction logic.

## Design Patterns

### Repository Pattern

Used to abstract data access.

### Strategy Pattern

Used for rental price calculation.

## Testing

The project includes:

* Unit Tests
* Integration Tests
* Coverage Collection

## Continuous Integration

GitHub Actions automatically builds and tests the project on pull requests.
