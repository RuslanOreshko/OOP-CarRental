using CarRental.Domain.Entities;

namespace CarRental.Application.Pricing;

public class StandartPriceStrategy : IPriceStrategy
{
    public decimal CalculatePrice(
        Car car,
        int rentalDay
    )
    {
        return car.PricePerDay * rentalDay;
    }
}