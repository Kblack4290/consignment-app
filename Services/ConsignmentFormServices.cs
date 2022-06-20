using ConsignmentApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ConsignmentApi.Services;

public class ConsignmentService
{
    private readonly IMongoCollection<ConsignmentData> _consignmentFormCollection;

    public ConsignmentService(
        IOptions<ConsignmentFormDatabaseSettings> consignmentFormDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            consignmentFormDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            consignmentFormDatabaseSettings.Value.DatabaseName);

        _consignmentFormCollection = mongoDatabase.GetCollection<ConsignmentData>(
            consignmentFormDatabaseSettings.Value.ConsignmentFormCollectionName);
    }

    public async Task<List<ConsignmentData>> GetAsync() =>
        await _consignmentFormCollection.Find(_ => true).ToListAsync();

    public async Task<ConsignmentData?> GetAsync(string id) =>
        await _consignmentFormCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ConsignmentData newItem) =>
        await _consignmentFormCollection.InsertOneAsync(newItem);

    public async Task UpdateAsync(string id, ConsignmentData updatedItem) =>
        await _consignmentFormCollection.ReplaceOneAsync(x => x.Id == id, updatedItem);

    public async Task RemoveAsync(string id) =>
        await _consignmentFormCollection.DeleteOneAsync(x => x.Id == id);
}