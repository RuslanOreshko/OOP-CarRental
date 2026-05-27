# Iteration 2 Plan

## Overview

The second iteration focuses on transforming the initial prototype into a more complete and extensible application.

The main goals of this iteration are:

- implement persistence;
- extend business logic;
- add LINQ queries;
- improve extensibility;
- increase test coverage.

# Planned Use Cases

The following use cases will be implemented or expanded:

1. View available cars
2. Rent a car
3. Return a rented car
4. Search and filter cars
5. Save and restore application state
6. View rental statistics

# Existing Components That Will Remain Stable

The following components from Lab 34 are expected to remain mostly unchanged:

- Car entity
- Customer entity
- Rental entity
- layered architecture structure
- basic repository abstractions
- console application entry point

# Planned Extension Points

The project will introduce extension mechanisms to improve flexibility and maintainability.

Planned extension points:

- pricing strategies;
- repository abstractions;
- LINQ extension methods;
- persistence contracts.

Strategy pattern will likely be used for rental pricing calculation.

# Planned Persistence Improvements

The application will support:

- JSON persistence;
- asynchronous file operations;
- loading and saving application state.

The persistence layer will remain replaceable to allow future migration to XML or database storage.

# Planned Business Rules

The system will include additional business rules such as:

- preventing double rental;
- rental duration limits;
- return validation;
- discount calculation;
- penalty handling.

# Planned LINQ Features

The system will support:

- filtering available cars;
- sorting cars by price;
- searching by multiple criteria;
- aggregated statistics.

# Risks And Potential Problems

Potential risks identified at the beginning of the iteration:

- duplicated validation logic;
- repository abstraction limitations;
- persistence synchronization issues;
- increasing complexity of console UI;
- testing asynchronous operations.

# Testing Goals

Testing coverage will be expanded to include:

- business rules;
- persistence logic;
- LINQ queries;
- pricing strategies;
- error scenarios.

# Expected Result

By the end of Iteration 2 the project should evolve from a basic prototype into a more realistic business application with persistence, extensibility, and richer domain logic.
