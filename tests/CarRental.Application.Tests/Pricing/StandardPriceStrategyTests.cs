using CarRental.Application.Pricing;
using CarRental.Domain.Entities;

namespace CarRental.Application.Tests.Pricing;

public class StandardPriceStrategyTests
{
    [Theory]
    [InlineData(100, 5, 500)]
    [InlineData(200, 2, 400)]
    [InlineData(50, 10, 500)]
    public void CalculatePrice_Should_Return_Correct_Price(
        decimal pricePerDay,
        int days,
        decimal expected)
    {
        var strategy =
            new StandartPriceStrategy();

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            pricePerDay);

        var result =
            strategy.CalculatePrice(car, days);

        Assert.Equal(expected, result);
    }
}