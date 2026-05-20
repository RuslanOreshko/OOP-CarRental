# Car Rental System

## Project Overview

Car Rental System is a console-based application for managing car rentals.
The system allows customers to view available cars, rent vehicles, and return them.

# Problem Statement

Car rental businesses need a simple way to manage vehicles, customers, and rental operations.
Manual management of rentals may lead to errors such as double booking, invalid rental periods, or incorrect vehicle availability tracking.

The system solves these problems by providing centralized rental management with business rules validation.

# Target Users

## Customers

Customers can:

- view available cars;
- rent cars;
- return rented vehicles.

## Administrators

Administrators can:

- manage vehicle inventory;
- monitor rentals;
- track car availability.

# Main Use Cases

## 1. View Available Cars

The user can see all cars currently available for rent.

## 2. Rent a Car

The user selects a car and rents it for a specified number of days.
The system validates car availability before creating the rental.

## 3. Return a Car

The user returns a rented car.
The system updates the vehicle status.

# Non-Functional Requirements

- The code must follow SOLID principles.
- The system must be easily extendable in future iterations.
- The application must be testable using unit tests.
- The project structure must be separated into layers.
- Business rules must be validated consistently.

# Iteration 1 Limitations

The first iteration intentionally does not include:

- database integration;
- graphical user interface;
- authentication and authorization;
- asynchronous operations;
- external APIs.

The first iteration focuses on:

- domain model;
- layered architecture;
- one working vertical slice;
- basic testing;
- project documentation.
