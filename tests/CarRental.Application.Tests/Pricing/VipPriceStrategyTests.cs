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
}