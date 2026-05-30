# User Guide

## Overview

Car Rental System is a console application for managing car rentals.

## Starting the Application

Run the application:

```bash
dotnet run --project src/CarRental.Console
```

## Main Menu

The application provides the following options:

1. View All Cars
2. View Available Cars
3. Search Cars By Brand
4. Rent Car
5. Return Car
6. Show Average Price
7. Exit

## Renting a Car

1. Select "Rent Car".
2. Enter the car identifier.
3. Enter the rental duration in days.
4. The system calculates the total price and creates a rental.

## Returning a Car

1. Select "Return Car".
2. Enter the rental identifier.
3. The system marks the car as available.

## Data Persistence

The application automatically stores car data in JSON format and restores it on startup.

## Error Handling

The application validates user input and displays messages when invalid operations are attempted.
