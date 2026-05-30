# Demo Script

## Duration

Approximately 3-5 minutes.


## Step 1 - Start Application

Run:

```bash id="q1xwuz"
dotnet run --project src/CarRental.Console
```

Show the main menu.


## Step 2 - View Cars

Select:

```text id="4h5zju"
View All Cars
```

Show available vehicles.


## Step 3 - Rent a Car

Select:

```text id="vgh4f4"
Rent Car
```

Enter a valid car id and rental duration.

Show successful rental creation.

---

## Step 4 - Negative Scenario

Attempt to rent the same car again.

Show validation and error handling.


## Step 5 - Return Car

Select:

```text id="7uj3s6"
Return Car
```

Enter rental id.

Show successful return.


## Step 6 - Persistence

Restart the application.

Show that data is restored from JSON storage.


## Step 7 - Architecture Explanation

Briefly explain:

* Repository Pattern
* Strategy Pattern
* Layered Architecture
* Testing Approach
