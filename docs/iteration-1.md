# Iteration 1 Report

## Overview

The first iteration of the car rental system focused on creating the architectural foundation of the project and implementing the first working vertical slice.

# Completed Work

## Documentation

The following project documentation was prepared:

- vision.md
- backlog.md
- class-diagram.md
- sequence-diagram.md

# Domain Layer

Implemented core business entities:

- Car
- Customer
- Rental

Added:

- business rules validation;
- encapsulation;
- repository abstractions.

Implemented interfaces:

- ICarRepository

# Application Layer

Implemented:

- Rental service abstraction;
- DTO models for requests and responses;
- rental workflow orchestration.

Added:

- IRentalCarService
- RentalCarService
- RentalCarRequest
- RentalCarResponse

# Infrastructure Layer

Implemented:

- InMemoryCarRepository

The repository currently stores data in memory and is used as a temporary persistence mechanism for the first iteration.

# Console Layer

Implemented:

- basic console user interface;
- car listing;
- car rental flow;
- user input validation.

The console application demonstrates a complete vertical slice from UI to domain logic.

# Architecture

The project uses:

- layered architecture;
- dependency injection;
- repository pattern;
- SOLID principles.

Project layers:

- Domain
- Application
- Infrastructure
- Console

# Current Limitations

The first iteration intentionally does not include:

- database integration;
- authentication;
- graphical user interface;
- persistent storage;
- advanced validation;
- asynchronous operations.
