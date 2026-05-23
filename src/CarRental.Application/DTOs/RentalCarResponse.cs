namespace CarRental.Application.DTOs;

public class RentalCarResponse
{
    public Guid RentalId { get; set; }
    public decimal TotalPrice { get; set; }
    public string Message { get; set;} = string.Empty;
}