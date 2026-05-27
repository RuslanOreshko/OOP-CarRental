using CarRental.Application.DTOs;

namespace CarRental.Application.Abstractions;


public interface IRentalCarService
{
    RentalCarResponse RentalCar(RentalCarRequest request);
    ReturnCarResponse ReturnCar(ReturnCarRequest request);
}