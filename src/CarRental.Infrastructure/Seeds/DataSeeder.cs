using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.Win32.SafeHandles;

namespace CarRental.Infrastructure.Seeds;

public class DataSeeder
{
    public static void SeedCars(
        IRepository<Car, Guid> repository
    )
    {
        repository.Add(
            new Car(
                Guid.NewGuid(),
                "BMW",
                "M5",
                120));

        repository.Add(
            new Car(
                Guid.NewGuid(),
                "Audi",
                "A6",
                100));

        repository.Add(
            new Car(
                Guid.NewGuid(),
                "Toyota",
                "Camry",
                80));
    }
}