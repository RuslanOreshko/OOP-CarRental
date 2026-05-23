using CarRental.Application.DTOs;

namespace CarRental.Application.Abstractions;


public interface IRentalCarService
{
    RentalCarRequest RentalCar(RentalCarRequest request);
}