namespace CarRental.Domain.Entities;

public class Car
{
    public Guid Id { get; }
    public string Brand { get; }
    public string Model { get; }
    public decimal PricePerDay { get; }
    public bool IsAvaible { get; set; }

    public Car(
        Guid id,
        string brand,
        string model,
        decimal pricePerDay
    )
    {
        if(Id == Guid.Empty)
            throw new ArgumentException("Car id cannot be empty.");

        if(string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Brand cannot be empty.");

        if(string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model cannot be ampty.");

        if(pricePerDay <= 0)
            throw new ArgumentException("Price per day must be greater than zero.");

        Id = id;
        Brand = brand;
        Model = model;
        PricePerDay = pricePerDay;

        IsAvaible = true;
    }

    public void Rent()
    {
        if(!IsAvaible)
            throw new InvalidOperationException("Car is already rented.");

        IsAvaible = false;
    }

    public void Return()
    {
        IsAvaible = true;
    }
}