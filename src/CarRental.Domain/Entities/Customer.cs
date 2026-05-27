using CarRental.Domain.Interfaces;

namespace CarRental.Domain.Entities;


public class Customer : IEntity<Guid>
{
    public Guid Id { get; }
    public string FullName { get; }
    public string Email { get; }

    public Customer(
        Guid id,
        string fullName,
        string email
    )
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Car id cannot be empty.");
        
        if(string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name cannot be empty.");

        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be ampty.");

        Id = id;
        FullName = fullName;
        Email = email;
    }
}