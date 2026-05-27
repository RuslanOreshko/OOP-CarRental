using CarRental.Application.Abstractions;
using CarRental.Application.DTOs;
using CarRental.Application.Pricing;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

public class RentalCarService : IRentalCarService
{
    private readonly IRepository<Car, Guid> _carRepository;
    private readonly IPriceStrategy _priceStrategy;

    public RentalCarService(
        IRepository<Car, Guid> carRepository,
        IPriceStrategy priceStrategy
        )
    {
        _carRepository = carRepository;
        _priceStrategy = priceStrategy;
    }

    public RentalCarResponse RentalCar(RentalCarRequest request)
    {
        var car = _carRepository.GetById(request.CarId);

        if(car == null)
            throw new InvalidOperationException("Car not found.");

        car.Rent();

        var customer = new Customer(
            request.CustomerId,
            "Test customer",
            "test@gmail.com"
        );

        var totalPrice = _priceStrategy.CalculatePrice(car, request.Days);

        var rental = new Rental(
            Guid.NewGuid(),
            car,
            customer,
            DateTime.UtcNow,
            request.Days,
            totalPrice
        );

        _carRepository.Update(car);

        return new RentalCarResponse{
            RentalId = rental.Id,
            TotalPrice = rental.TotalPrice,
            Message = "Car rented successfully"
        };
    }
}
