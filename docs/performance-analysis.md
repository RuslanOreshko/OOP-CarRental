# Performance Analysis

## Overview

The Car Rental System stores data in memory using collections and saves data to JSON files.

For the expected number of cars and rentals, the application works efficiently and does not require additional optimization.

---

## Search Operations

### Search Car By Id

Current complexity:

```text
O(n)
```

The system searches through the collection until the required car is found.

---

### Search Cars By Brand

Current complexity:

```text
O(n)
```

All cars are checked to find those matching the selected brand.

---

## Rental Operations

### Rent Car

Current complexity:

```text
O(n)
```

The most expensive operation is finding the selected car.

### Return Car

Current complexity:

```text
O(n)
```

The most expensive operation is finding the rental record.

---

## Data Persistence

### Save Data

Current complexity:

```text
O(n)
```

All cars are serialized into a JSON file.

### Load Data

Current complexity:

```text
O(n)
```

All cars are deserialized from a JSON file.

---

## Possible Improvements

If the project grows in the future, performance could be improved by:

* Using `Dictionary<Guid, T>` for faster searches
* Storing data in a database instead of JSON files
* Adding indexes for frequently used searches

---

## Conclusion

The current implementation provides acceptable performance for the project requirements and expected amount of data. No additional optimization is required at this stage.
