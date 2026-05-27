using CarRental.Domain.Entities;

namespace CarRental.Application.Exstensions;


public static class CarExtensions
{
    public static IEnumerable<Car> GetAvailableCars(
        this IEnumerable<Car> cars
    )
    {
        return cars.Where(x => x.IsAvaible);
    }

    public static IEnumerable<Car> GetCarByBrand(
        this IEnumerable<Car> cars,
        string brand
    )
    {
        return cars.Where(x => x.Brand.Equals(
            brand,
            StringComparison.OrdinalIgnoreCase
        ));
    }

    public static IEnumerable<Car> GeyByExpensiveCars(
        this IEnumerable<Car> cars
    )
    {
        return cars.OrderByDescending(x => x.PricePerDay);
    }

    public static decimal GetAveragePrice(
        this IEnumerable<Car> cars
    )
    {
        return cars.Average(x => x.PricePerDay);
    }
}