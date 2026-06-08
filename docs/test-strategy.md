# Test Strategy

## Purpose

The purpose of testing is to verify the correctness, reliability, and maintainability of the Car Rental System before the final iteration.

## Critical Scenarios

The following scenarios are considered critical:

1. Renting a car
2. Returning a rented car
3. Saving data to JSON storage
4. Loading data from JSON storage
5. Price calculation using pricing strategies

## High-Risk Areas

### Persistence Layer

Risks:

- Missing JSON file
- Corrupted JSON file
- Data loss after application restart

### Rental Workflow

Risks:

- Renting unavailable cars
- Returning non-existing rentals
- Invalid rental duration

### Extension Methods

Risks:

- Empty collections
- Invalid filtering results

## Testing Approach

### Unit Tests

Unit tests are used for:

- Domain entities
- Rental service
- Pricing strategies
- Extension methods

### Integration Tests

Integration tests are used for:

- JSON persistence
- Save/load operations
- End-to-end business workflows

## Mocking Strategy

Current implementation primarily uses in-memory repositories.

Mocks may be introduced in future iterations for external dependencies.

## Negative Scenarios

The following negative cases must be covered:

- Car not found
- Rental not found
- Renting unavailable car
- Missing JSON file
- Corrupted JSON file
