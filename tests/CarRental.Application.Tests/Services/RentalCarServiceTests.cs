using CarRental.Application.DTOs;
using CarRental.Application.Pricing;
using CarRental.Application.Services;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Repositories;

namespace CarRental.Application.Tests.Services;

public class RentalCarServiceTest
{
    [Fact]
    public void RentalCar_Should_Create_Rental()
    {
        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                new StandartPriceStrategy());

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

        Assert.Single(rentalRepository.GetAll());
    }

    [Fact]
    public void RentalCar_Should_Mark_Car_As_Unavailable()
    {
        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                new StandartPriceStrategy());

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
    public void RentalCar_Should_Return_Correct_TotalPrice()
    {
        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                new StandartPriceStrategy());

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

        var result =
            service.RentalCar(request);

        Assert.Equal(500, result.TotalPrice);
    }

    [Fact]
    public void RentalCar_Should_Throw_When_Car_Not_Found()
    {
        var service =
            new RentalCarService(
                new InMemoryRepository<Car, Guid>(),
                new InMemoryRepository<Rental, Guid>(),
                new StandartPriceStrategy());

        var request = new RentalCarRequest
        {
            CarId = Guid.NewGuid(),
            CustomerId = Guid.NewGuid(),
            Days = 5
        };

        Assert.Throws<InvalidOperationException>(
            () => service.RentalCar(request));
    }

    [Fact]
    public void RentalCar_Should_Throw_When_Car_Is_Already_Rented()
    {
        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                new StandartPriceStrategy());

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);

        car.Rent();

        carRepository.Add(car);

        var request = new RentalCarRequest
        {
            CarId = car.Id,
            CustomerId = Guid.NewGuid(),
            Days = 5
        };

        Assert.Throws<InvalidOperationException>(
            () => service.RentalCar(request));
    }

    [Fact]
    public void ReturnCar_Should_Throw_When_Rental_Not_Found()
    {
        var service =
            new RentalCarService(
                new InMemoryRepository<Car, Guid>(),
                new InMemoryRepository<Rental, Guid>(),
                new StandartPriceStrategy());

        Assert.Throws<InvalidOperationException>(
            () => service.ReturnCar(
                new ReturnCarRequest
                {
                    RentalId = Guid.NewGuid()
                }));
    }

    [Fact]
    public void ReturnCar_Should_Keep_Rental_In_Repository()
    {
        var carRepository =
            new InMemoryRepository<Car, Guid>();

        var rentalRepository =
            new InMemoryRepository<Rental, Guid>();

        var service =
            new RentalCarService(
                carRepository,
                rentalRepository,
                new StandartPriceStrategy());

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);

        carRepository.Add(car);

        var rental =
            service.RentalCar(
                new RentalCarRequest
                {
                    CarId = car.Id,
                    CustomerId = Guid.NewGuid(),
                    Days = 5
                });

        service.ReturnCar(
            new ReturnCarRequest
            {
                RentalId = rental.RentalId
            });

        Assert.Single(rentalRepository.GetAll());
    }
}