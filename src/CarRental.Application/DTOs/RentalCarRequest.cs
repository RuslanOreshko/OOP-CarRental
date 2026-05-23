namespace CarRental.Application.DTOs;

public class RentalCarRequest
{
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public int Days { get; set; }
}