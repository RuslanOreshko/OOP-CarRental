using CarRental.Infrastructure.Repositories;
using CarRental.Application.Services;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Seeds;
using CarRental.Infrastructure.Persistences;
using CarRental.Application.Pricing;
using CarRental.ConsoleUI.Menu;

var carRepository = new InMemoryRepository<Car, Guid>();
var rentalRepository = new InMemoryRepository<Rental, Guid>();

IPriceStrategy vipPriceStrategy = new VipPriceStrategy();

var rentalService = new RentalCarService
(
    carRepository, 
    rentalRepository,
    vipPriceStrategy
);



var jsonStore = new JsonDataStore<Car>("Data/cars.json");

var cars = await jsonStore.LoadAsync();

if (!cars.Any())
{
    DataSeeder.SeedCars(carRepository);

    var seededCars = carRepository.GetAll().ToList();

    await jsonStore.SaveAsync(seededCars);
}
else
{
    foreach(var car in cars)
    {
        carRepository.Add(car);
    }
}



var menu = new ConsoleMenu(
    carRepository,
    rentalRepository,
    rentalService,
    jsonStore
);

await menu.StartAsync();