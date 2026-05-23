using CarRental.Domain.Entities;

namespace CarRental.Domain.Interfaces;


public interface ICarRepository
{
    Car? GetById(Guid id);
    IEnumerable<Car> GetAll();
    void Add(Car car);
    void Update(Car car);
}