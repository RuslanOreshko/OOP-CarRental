using CarRental.Domain.Entities;

namespace CarRental.Domain.Interfaces;


public interface IRepository<T, TId>
{
    IReadOnlyCollection<T> GetAll();
    T? GetById(TId id);
    void Add(T entity);
    void Update(T entity);
    void Remove(TId id);
}