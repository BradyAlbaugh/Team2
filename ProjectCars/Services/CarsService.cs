using ProjectCars.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProjectCars.Services;

public class CarsService
{
    private readonly IMongoCollection<Cars> _carsCollection;

    public CarsService(IOptions<CarsDatabaseSettings> carsDatabaseSettings)
    {
        var mongoClient = new MongoClient(carsDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(carsDatabaseSettings.Value.DatabaseName);

        _carsCollection = mongoDatabase.GetCollection<Cars>(carsDatabaseSettings.Value.CarsCollectionName);
    }

    public async Task<List<Cars>> GetAsync() => await _carsCollection.Find(_ => true).ToListAsync();

    public async Task<Cars?> GetAsync(string id) => await _carsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Cars newCars) => await _carsCollection.InsertOneAsync(newCars);

    public async Task UpdateAsync(string id, Cars updatedCars) => await _carsCollection.ReplaceOneAsync(x => x.Id == id, updatedCars);

    public async Task RemoveAsync(string id) => await _carsCollection.DeleteOneAsync(x => x.Id == id);
}
