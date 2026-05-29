using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistences;

namespace CarRental.Application.Tests.Integration;

public class PersistenceIntegrationTests
{
    [Fact]
    public async Task SaveAndLoad_Should_Preserve_Car_Count()
    {
        var filePath = Path.GetTempFileName();

        var store = new JsonDataStore<Car>(filePath);

        var cars = new List<Car>
        {
            new(Guid.NewGuid(), "BMW", "M5", 100),
            new(Guid.NewGuid(), "Audi", "A6", 80),
            new(Guid.NewGuid(), "Toyota", "Camry", 60)
        };

        await store.SaveAsync(cars);

        var loadedCars = await store.LoadAsync();

        Assert.Equal(3, loadedCars.Count);

        File.Delete(filePath);
    }

    [Fact]
    public async Task SaveAndLoad_Should_Preserve_Car_Data()
    {
        var filePath = Path.GetTempFileName();

        var store = new JsonDataStore<Car>(filePath);

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);

        await store.SaveAsync([car]);

        var loadedCars = await store.LoadAsync();

        var loadedCar = loadedCars.First();

        Assert.Equal(car.Brand, loadedCar.Brand);
        Assert.Equal(car.Model, loadedCar.Model);
        Assert.Equal(car.PricePerDay, loadedCar.PricePerDay);

        File.Delete(filePath);
    }

    [Fact]
    public async Task LoadAsync_Should_Return_Empty_When_File_Does_Not_Exist()
    {
        var filePath =
            Path.Combine(
                Path.GetTempPath(),
                $"{Guid.NewGuid()}.json");

        var store =
            new JsonDataStore<Car>(filePath);

        var cars =
            await store.LoadAsync();

        Assert.Empty(cars);
    }

    [Fact]
    public async Task LoadAsync_Should_Return_Empty_When_Json_Is_Corrupted()
    {
        var filePath = Path.GetTempFileName();

        await File.WriteAllTextAsync(
            filePath,
            "{ invalid json");

        var store =
            new JsonDataStore<Car>(filePath);

        var cars =
            await store.LoadAsync();

        Assert.Empty(cars);

        File.Delete(filePath);
    }

    [Fact]
    public async Task SaveAsync_Should_Create_File()
    {
        var filePath = Path.GetTempFileName();

        File.Delete(filePath);

        var store =
            new JsonDataStore<Car>(filePath);

        await store.SaveAsync([]);

        Assert.True(File.Exists(filePath));

        File.Delete(filePath);
    }

    [Fact]
    public async Task Multiple_Save_Operations_Should_Not_Throw()
    {
        var filePath = Path.GetTempFileName();

        var store =
            new JsonDataStore<Car>(filePath);

        var cars = new List<Car>
        {
            new(Guid.NewGuid(), "BMW", "M5", 100)
        };

        await store.SaveAsync(cars);

        await store.SaveAsync(cars);

        await store.SaveAsync(cars);

        var loadedCars =
            await store.LoadAsync();

        Assert.Single(loadedCars);

        File.Delete(filePath);
    }

    [Fact]
    public async Task SaveAndLoad_Should_Preserve_Rented_State()
    {
        var filePath = Path.GetTempFileName();

        var store =
            new JsonDataStore<Car>(filePath);

        var car = new Car(
            Guid.NewGuid(),
            "BMW",
            "M5",
            100);

        car.Rent();

        await store.SaveAsync([car]);

        var loadedCars =
            await store.LoadAsync();

        var loadedCar =
            loadedCars.First();

        Assert.False(loadedCar.IsAvaible);

        File.Delete(filePath);
    }

    [Fact]
    public async Task Loaded_Data_Should_Be_Reusable()
    {
        var filePath = Path.GetTempFileName();

        var store =
            new JsonDataStore<Car>(filePath);

        await store.SaveAsync(
        [
            new Car(
                Guid.NewGuid(),
                "BMW",
                "M5",
                100)
        ]);

        var loadedCars =
            await store.LoadAsync();

        var car =
            loadedCars.First();

        Assert.Equal("BMW", car.Brand);

        File.Delete(filePath);
    }
}