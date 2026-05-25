using CarRental.Application.DTOs;
using CarRental.Infrastructure.Repositories;
using CarRental.Application.Services;
using CarRental.Domain.Entities;

var carRepository = new InMemoryCarRepository<Car, Guid>();

carRepository.Add(
    new Car(
        Guid.NewGuid(),
        "Toyota",
        "Camry",
        90
    )
);

var rentalService = new RentalCarService(carRepository);

Console.WriteLine("Car Rental System");
Console.WriteLine();

var cars = carRepository.GetAll().ToList();

Console.WriteLine("Available cars:");

foreach(var car in cars)
{
    Console.WriteLine(
        $"{car.Id} | {car.Brand} | {car.Model} | ${car.PricePerDay}/day | Available: {car.IsAvaible}"
    );
}

Console.WriteLine();
Console.Write("Enter car id: ");

var carIdInput = Console.ReadLine();

if(!Guid.TryParse(carIdInput, out var carId))
{
    Console.WriteLine("Invalid car id.");
    return;
}

Console.Write("Enter rental days: ");

if (!int.TryParse(Console.ReadLine(), out var days))
{
    Console.WriteLine("Invalid days.");
    return;
}

var request = new RentalCarRequest
{
  CarId = carId,
  CustomerId = Guid.NewGuid(),
  Days = days
};

try
{
    var response = rentalService.RentalCar(request);

    Console.WriteLine();
    Console.WriteLine(response.Message);
    Console.WriteLine($"Rental Id: {response.RentalId}");
    Console.WriteLine($"Total Price: ${response.TotalPrice}");
}
catch (Exception ex)
{
   Console.WriteLine($"Error: {ex.Message}"); 
}