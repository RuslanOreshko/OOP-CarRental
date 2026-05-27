using CarRental.Domain.Entities;

namespace CarRental.Application.Pricing;


public interface IPriceStrategy
{
    decimal CalculatePrice(
        Car car,
        int rentalDay
    );
}