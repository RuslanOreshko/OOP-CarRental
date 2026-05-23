using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Infrastructure.Repositories;

public class InMemoryCarRepository : ICarRepository
{
    private readonly List<Car> _cars = new();

    public InMemoryCarRepository()
    {
        _cars.Add(new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            120));

        _cars.Add(new Car(
            Guid.NewGuid(),
            "Audi",
            "A6",
            100));

        _cars.Add(new Car(
            Guid.NewGuid(),
            "Toyota",
            "Camry",
            80));
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public IEnumerable<Car> GetAll()
    {
        return _cars;
    }

    public Car? GetById(Guid id)
    {
        return _cars.FirstOrDefault(c => c.Id == id);
    }

    public void Update(Car car)
    {
    }
}