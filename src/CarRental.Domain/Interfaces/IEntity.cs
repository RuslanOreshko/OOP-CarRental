namespace CarRental.Domain.Interfaces;


public interface IEntity<TId>
{
    TId Id { get; }
}