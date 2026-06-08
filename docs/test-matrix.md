# Test Matrix

| Use Case                  | Unit Tests             | Integration Tests        |
| ------------------------- | ---------------------- | ------------------------ |
| View Available Cars       | GetAvailableCars tests | Persistence reload tests |
| Search Cars By Brand      | GetCarsByBrand tests   | Persistence reload tests |
| Rent Car                  | RentalCarService tests | Rent + Save + Reload     |
| Return Car                | ReturnCar tests        | Return + Save + Reload   |
| Save Application State    | JsonDataStore tests    | Save and Reload tests    |
| Restore Application State | JsonDataStore tests    | Load existing file tests |
| Price Calculation         | Strategy tests         | Rental workflow tests    |

## Coverage Areas

### Domain

- Car state transitions
- Rental creation

### Application

- Rental service
- Pricing strategies
- Extension methods

### Infrastructure

- JSON persistence
- Repository operations
