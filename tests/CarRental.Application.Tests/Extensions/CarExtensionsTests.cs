using CarRental.Application.Exstensions;
using CarRental.Domain.Entities;

namespace CarRental.Application.Tests.Extensions;

public class CarExtensionsTests
{
    [Fact]
    public void GetAvailableCars_Should_Return_Only_Available_Cars()
    {

        var car1 = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);

        var car2 = new Car(
            Guid.NewGuid(),
            "Audi",
            "A6",
            80);

        car2.Rent();

        var cars = new List<Car>
        {
            car1,
            car2
        };


        var result =
            cars.GetAvailableCars();


        Assert.Single(result);

        Assert.Contains(car1, result);
    }

    [Fact]
    public void GetAveragePrice_Should_Return_Correct_Average()
    {

        var cars = new List<Car>
        {
            new Car(
                Guid.NewGuid(),
                "BMW",
                "M5",
                100),

            new Car(
                Guid.NewGuid(),
                "Audi",
                "A6",
                200)
        };


        var average =
            cars.GetAveragePrice();


        Assert.Equal(150, average);
    }
}