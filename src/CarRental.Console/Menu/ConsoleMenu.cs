using CarRental.Application.DTOs;
using CarRental.Application.Exstensions;
using CarRental.Application.Services;
using CarRental.Application.Abstractions;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI.Menu;

public class ConsoleMenu
{
    private readonly IRepository<Car, Guid> _carRepository;
    private readonly IRepository<Rental, Guid> _rentalRepository;
    private readonly IRentalCarService _rentalService;
    private readonly IDataStore<Car> _dataStore;

    public ConsoleMenu(
        IRepository<Car, Guid> carRepository,
        IRepository<Rental, Guid> rentalRepository,
        RentalCarService rentalService,
        IDataStore<Car> dataStore
        )
    {
        _carRepository = carRepository;
        _rentalRepository = rentalRepository;
        _rentalService = rentalService;
        _dataStore = dataStore;
    }

    public async Task StartAsync()
    {
        while (true)
        {
            ShowMenu();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowAllCars();
                    break;

                case "2":
                    ShowAvailableCars();
                    break;

                case "3":
                    SearchCarsByBrand();
                    break;

                case "4":
                    await RentCar();
                    break;

                case "5":
                    await ReturnCar();
                    break;

                case "6":
                    ShowAveragePrice();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("=== Car Rental System ===");
        Console.WriteLine("1. View All Cars");
        Console.WriteLine("2. View Available Cars");
        Console.WriteLine("3. Search Cars By Brand");
        Console.WriteLine("4. Rent Car");
        Console.WriteLine("5. Return Car");
        Console.WriteLine("6. Show Average Price");
        Console.WriteLine("0. Exit");

        Console.Write("Choose option: ");
    }

    private void ShowAllCars()
    {
        var cars = _carRepository.GetAll();

        foreach (var car in cars)
        {
            PrintCar(car);
        }
    }

    private void ShowAvailableCars()
    {
        var cars = _carRepository
            .GetAll()
            .GetAvailableCars();

        foreach (var car in cars)
        {
            PrintCar(car);
        }
    }

    private void SearchCarsByBrand()
    {
        Console.Write("Enter brand: ");

        var brand = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(brand))
        {
            Console.WriteLine("Invalid brand.");
            return;
        }

        var cars = _carRepository
            .GetAll()
            .GetCarByBrand(brand);

        foreach (var car in cars)
        {
            PrintCar(car);
        }
    }

    private async Task RentCar()
    {
        Console.Write("Enter car id: ");

        var carIdInput = Console.ReadLine();

        if (!Guid.TryParse(carIdInput, out var carId))
        {
            Console.WriteLine("Invalid id.");
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
            var response =
                _rentalService.RentalCar(request);

            await _dataStore.SaveAsync(
                _carRepository.GetAll().ToList()
            );

            Console.WriteLine(response.Message);
            Console.WriteLine(
                $"Total price: ${response.TotalPrice}");

            Console.WriteLine($"Rentall id: {response.RentalId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task ReturnCar()
    {
        Console.Write("Enter rental id: ");

        var rentalIdInput = Console.ReadLine();

        if (!Guid.TryParse(rentalIdInput, out var rentalId))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var request = new ReturnCarRequest
        {
            RentalId = rentalId
        };

        try
        {
            var response = 
                _rentalService.ReturnCar(request);

            await _dataStore.SaveAsync(
                _carRepository.GetAll().ToList()
            );

            Console.WriteLine(response.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowAveragePrice()
    {
        var average = _carRepository
            .GetAll()
            .GetAveragePrice();

        Console.WriteLine(
            $"Average price: ${average}");
    }

    private void PrintCar(Car car)
    {
        Console.WriteLine(
            $"{car.Id} | " +
            $"{car.Brand} | " +
            $"{car.Model} | " +
            $"${car.PricePerDay}/day | " +
            $"Available: {car.IsAvaible}");
    }
}