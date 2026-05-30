# Final Report

## Project Overview

Car Rental System is a console application developed as a course project to demonstrate object-oriented programming principles, software architecture, testing, persistence, and design patterns.

The system allows users to view available cars, rent cars, return rented cars, search cars by brand, and save application state using JSON persistence.


## Implemented Functionality

### Core Features

* View all cars
* View available cars
* Search cars by brand
* Rent a car
* Return a car
* Calculate rental price
* Save and restore data from JSON

### Additional Features

* LINQ-based filtering
* Generic repository implementation
* Automated testing
* Continuous Integration


## Architecture

The application follows a layered architecture:

* Domain Layer
* Application Layer
* Infrastructure Layer
* Console UI Layer

This separation improves maintainability and testability.


## Applied Design Patterns

### Repository Pattern

Used to abstract data access and storage operations.

### Strategy Pattern

Used for rental price calculation.


## SOLID Principles

The project demonstrates:

* Single Responsibility Principle
* Open/Closed Principle
* Dependency Inversion Principle

through service abstractions, repositories, and pricing strategies.


## Testing

Testing includes:

* Unit Tests
* Integration Tests
* Coverage Collection

The testing process verifies business logic, persistence operations, and negative scenarios.


## Refactoring

During the final iteration:

* Improved code readability
* Removed duplicated logic
* Added XML documentation comments
* Improved naming consistency
* Simplified extension methods


## Challenges

The most challenging parts of the project were:

* Designing repository abstractions
* Implementing JSON persistence
* Organizing the layered architecture
* Creating automated tests


## Future Improvements

Potential future enhancements:

* Database integration
* Authentication and authorization
* Reservation management
* Web API implementation
* Advanced reporting


## Conclusion

The project successfully demonstrates the integration of key topics covered during the course, including OOP, generics, collections, LINQ, persistence, testing, design patterns, UML, and refactoring.

The application is stable, tested, documented, and ready for release version v1.0.0.
