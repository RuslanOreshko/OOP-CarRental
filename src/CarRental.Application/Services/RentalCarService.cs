using CarRental.Application.Abstractions;
using CarRental.Application.DTOs;
using CarRental.Application.Pricing;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

public class RentalCarService : IRentalCarService
{
    private readonly IRepository<Car, Guid> _carRepository;
    private readonly IRepository<Rental, Guid> _rentalRepository;
    private readonly IPriceStrategy _priceStrategy;

    public RentalCarService(
        IRepository<Car, Guid> carRepository,
        IRepository<Rental, Guid> rentalRepository,
        IPriceStrategy priceStrategy
        )
    {
        _carRepository = carRepository;
        _rentalRepository = rentalRepository;
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

        _rentalRepository.Add(rental);

        return new RentalCarResponse{
            RentalId = rental.Id,
            TotalPrice = rental.TotalPrice,
            Message = "Car rented successfully"
        };
    }

    public ReturnCarResponse ReturnCar(
        ReturnCarRequest request
    )
    {
        var rental = _rentalRepository.GetById(request.RentalId);

        if(rental == null)
            throw new InvalidOperationException("Rental not found.");

        rental.Car.Return();

        return new ReturnCarResponse
        {
            Message = "Car return successfully"
        };
    }
}
