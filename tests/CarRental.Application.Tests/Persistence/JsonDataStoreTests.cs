using CarRental.Application.DTOs;
using CarRental.Application.Pricing;
using CarRental.Application.Services;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Repositories;

namespace CarRental.Application.Tests.Services;

public class RentalCarServiceTests
{
    [Fact]
    public void RentCar_Should_Mark_Car_As_Unavailable()
    {
        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var strategy =
            new StandartPriceStrategy();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                strategy);

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);

        carRepository.Add(car);

        var request = new RentalCarRequest
        {
            CarId = car.Id,
            CustomerId = Guid.NewGuid(),
            Days = 5
        };


        service.RentalCar(request);


        Assert.False(car.IsAvaible);
    }

    [Fact]
    public void RentCar_Should_Throw_Exception_When_Car_Not_Found()
    {

        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var strategy =
            new StandartPriceStrategy();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                strategy);

        var request = new RentalCarRequest
        {
            CarId = Guid.NewGuid(),
            CustomerId = Guid.NewGuid(),
            Days = 5
        };


        Assert.Throws<InvalidOperationException>(() =>
        {
            service.RentalCar(request);
        });
    }

    [Fact]
    public void ReturnCar_Should_Mark_Car_As_Available()
    {

        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var strategy =
            new StandartPriceStrategy();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                strategy);

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);

        car.Rent();

        carRepository.Add(car);

        var rental = new Rental(
            Guid.NewGuid(),
            car,
            new Customer(
                Guid.NewGuid(),
                "Ruslan",
                "test@gmail.com"),
            DateTime.UtcNow,
            5,
            500);

        rentalRepository.Add(rental);

        var request = new ReturnCarRequest
        {
            RentalId = rental.Id
        };


        service.ReturnCar(request);


        Assert.True(car.IsAvaible);
    }
}