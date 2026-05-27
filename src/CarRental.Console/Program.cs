using CarRental.Application.DTOs;
using CarRental.Infrastructure.Repositories;
using CarRental.Application.Services;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Seeds;
using CarRental.Infrastructure.Persistences;
using CarRental.Application.Exstensions;
using CarRental.Application.Pricing;

var carRepository = new InMemoryCarRepository<Car, Guid>();
var vipPriceStrategy = new VipPriceStrategy();

var jsonStore = new JsonDataStore<Car>("Data/cars.json");

var rentalService = new RentalCarService(carRepository, vipPriceStrategy);


Console.WriteLine("Car Rental System");
Console.WriteLine();

var cars = await jsonStore.LoadAsync();
if(!cars.Any())
{
    DataSeeder.SeedCars(carRepository);

    var carsInRepo = carRepository.GetAll().ToList();

    await jsonStore.SaveAsync(carsInRepo);

    cars = carsInRepo;
}
else
{
    foreach(var car in cars)
    {
        carRepository.Add(car);
    }
}


Console.WriteLine("Available cars:");

foreach(var car in cars.GeyByExpensiveCars())
{
    Console.WriteLine(
        $"{car.Id} | {car.Brand} | {car.Model} | ${car.PricePerDay}/day | Available: {car.IsAvaible}"
    );
}


// Console.WriteLine("Car by brand");
// Console.Write("Enter brand: ");

// var brandInput = Console.ReadLine();

// if (!string.IsNullOrWhiteSpace(brandInput))
// {
//     foreach(var car in cars.GetCarByBrand(brandInput))
//     {
//         Console.WriteLine(
//             $"{car.Id} | {car.Brand} | {car.Model} | ${car.PricePerDay}/day | Available: {car.IsAvaible}"
//         );
//     }
// }



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

    await jsonStore.SaveAsync(carRepository.GetAll().ToList());

    Console.WriteLine();
    Console.WriteLine(response.Message);
    Console.WriteLine($"Rental Id: {response.RentalId}");
    Console.WriteLine($"Total Price: ${response.TotalPrice}");
}
catch (Exception ex)
{
   Console.WriteLine($"Error: {ex.Message}"); 
}