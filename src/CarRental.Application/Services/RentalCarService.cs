using CarRental.Application.Abstractions;
using CarRental.Application.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

public class RentalCarService : IRentalCarService
{
    private readonly ICarRepository _carRepository;

    public RentalCarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
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

        var rental = new Rental(
            Guid.NewGuid(),
            car,
            customer,
            DateTime.UtcNow,
            request.Days
        );

        _carRepository.Update(car);

        return new RentalCarResponse{
            RentalId = rental.Id,
            TotalPrice = rental.TotalPrice,
            Message = "Car rented successfully"
        };
    }
}
