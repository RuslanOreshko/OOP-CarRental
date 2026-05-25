using System.ComponentModel.DataAnnotations;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Infrastructure.Repositories;

public class InMemoryCarRepository<T, TId> : IRepository<T, TId> where T : IEntity<TId>
{
    private readonly List<T> _items = new();

    public IReadOnlyCollection<T> GetAll()
    {
        return _items;
    }

    public T? GetById(TId id)
    {
        return _items.FirstOrDefault(x => x.Id!.Equals(id));
    }

    public void Add(T entity)
    {
        _items.Add(entity);
    }

    public void Update(T entity)
    {
        
    }

    public void Remove(TId id)
    {
        var entity = GetById(id);

        if(entity != null)
        {
            _items.Remove(entity);
        }
    }
}