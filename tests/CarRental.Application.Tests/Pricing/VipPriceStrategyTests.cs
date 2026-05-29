using CarRental.Application.Pricing;
using CarRental.Domain.Entities;

namespace CarRental.Application.Tests.Pricing;

public class VipPriceStrategyTests
{
    [Fact]
    public void CalculatePrice_Should_Apply_20_Percent_Discount()
    {

        var strategy =
            new VipPriceStrategy();

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);


        var result =
            strategy.CalculatePrice(car, 5);


        Assert.Equal(400, result);
    }

    [Theory]
    [InlineData(100, 5, 400)]
    [InlineData(200, 2, 320)]
    [InlineData(50, 10, 400)]
    public void CalculatePrice_Should_Apply_Discount(
        decimal pricePerDay,
        int days,
        decimal expected)
    {
        var strategy =
            new VipPriceStrategy();

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