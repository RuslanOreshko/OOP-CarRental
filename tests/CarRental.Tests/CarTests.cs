using CarRental.Domain.Entities;

namespace CarRental.Tests;

public class CarTest
{
    [Fact]
    public void Customee_Should_ThrowException_WhenPriceInvalid()
    {
        var action = () => new Car
        (
            Guid.NewGuid(),
            "BMW",
            "M5",
            0
        );

        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Rent_Should_MakeCarUnavailable()
    {
        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100
        );

        car.Rent();

        Assert.False(car.IsAvaible);
    }

    [Fact]
    public void Rent_Should_ThrowException_WhenCarAlreadyRented()
    {
        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100
        );

        car.Rent();

        var action = () => car.Rent();

        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void Return_Should_MakeCarAvailable()
    {
        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100
        );

        car.Rent();

        car.Return();

        Assert.True(car.IsAvaible);
    }
}
