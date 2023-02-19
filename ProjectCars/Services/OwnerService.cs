using ProjectCars.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProjectCars.Services;

public class OwnerService
{
    private readonly IMongoCollection<Owner> _ownerCollection;

    public OwnerService(IOptions<OwnerDatabaseSettings> ownerDatabaseSettings)
    {
        var mongoClient = new MongoClient(ownerDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(ownerDatabaseSettings.Value.DatabaseName);

        _ownerCollection = mongoDatabase.GetCollection<Owner>(ownerDatabaseSettings.Value.OwnerCollectionName);
    }

    public async Task<List<Owner>> GetAsync() => await _ownerCollection.Find(_ => true).ToListAsync();

    public async Task<Owner?> GetAsync(string id) => await _ownerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Owner newOwner) => await _ownerCollection.InsertOneAsync(newOwner);

    public async Task UpdateAsync(string id, Owner updatedOwner) => await _ownerCollection.ReplaceOneAsync(x => x.Id == id, updatedOwner);

    public async Task RemoveAsync(string id) => await _ownerCollection.DeleteOneAsync(x => x.Id == id);
}
