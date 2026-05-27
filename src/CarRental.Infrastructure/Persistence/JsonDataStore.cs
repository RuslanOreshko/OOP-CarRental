using System.Text.Json;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Seeds;

namespace CarRental.Infrastructure.Persistences;

public class JsonDataStore<T> : IDataStore<T>
{
    private readonly string _filePath;

    public JsonDataStore(string filePath)
    {
        _filePath = filePath;
    }

    public async Task SaveAsync(
        IReadOnlyCollection<T> items,
        CancellationToken cancellationToken = default
    )
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(items, options);
    
        await File.WriteAllTextAsync(
            _filePath,
            json,
            cancellationToken
        );
    }

    public async Task<IReadOnlyCollection<T>> LoadAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return [];
            } 

            var file = await File.ReadAllTextAsync(_filePath, cancellationToken);

            var items = JsonSerializer.Deserialize<List<T>>(file);

            if(items == null)
            {
                return [];
            }

            return items;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"the file is corrupted: {ex.Message}");   

            return [];
        }
    }
}