using CarRental.Domain.Entities;

namespace CarRental.Application.Pricing;

public class VipPriceStrategy : IPriceStrategy
{
    public decimal CalculatePrice(
        Car car,
        int rentalDay
    )
    {
        var total = car.PricePerDay * rentalDay;

        return total * 0.8m;
    }
}