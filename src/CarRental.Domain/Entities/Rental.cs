using System.Security.Cryptography.X509Certificates;

namespace CarRental.Domain.Entities;


public class Rental
{
    public Guid Id { get; }
    public Car Car { get; } = default!;
    public Customer Customer { get; } = default!;
    public DateTime StartDate { get; }
    public int Days { get; }
    public decimal TotalPrice { get; }

    public Rental(
        Guid id,
        Car car,
        Customer customer,
        DateTime stratDate,
        int days
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Car id cannot be empty.");

        if(car == null)
            throw new ArgumentNullException(nameof(car));

        if(customer == null)
            throw new ArgumentNullException(nameof(customer));

        if(days <= 0)
            throw new ArgumentException("Days must be greate than zero.");

        Id = id;
        Car = car;
        Customer = customer;
        StartDate = stratDate;
        Days = days;
        TotalPrice = car.PricePerDay * days;
    }
}