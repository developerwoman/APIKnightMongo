using APIKnightMongo.Entities;
using APIKnightMongo.Repositories.Interfaces;
using MongoDB.Driver;
using APIKnightMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Amazon.Runtime;

namespace APIKnightMongo.Repositories
{
    public class KnightRepository : IKnightRepository
    {
        private readonly IMongoCollection<Knight> _collection;       
        private readonly DbConfiguration _settings;

        public KnightRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Knight>(_settings.CollectionName);           
        }

        public async Task<Knight> CreateAsync(Knight knight)
        {
            await _collection.InsertOneAsync(knight).ConfigureAwait(false);
            return knight;
        }

        public Task DeleteAsync(int id)
        {
            return _collection.DeleteOneAsync(c => c.KnightId == id);
        }

        public async Task<List<Knight>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }
        public async Task<Knight> GetByIdAsync(int id)
        {
            return await _collection.Find(c => c.KnightId == id).FirstOrDefaultAsync();
        }
        public List<BsonDocument> GetWeaponsByKnightIdAsync(int knightId)
        {
            var result = _collection
                 .Aggregate()
                 .Unwind(i => i.KnightWeapon)
                 .Group(new BsonDocument
                 {
                    { "_id", "$KnightId" },
                    { "Weapons", new BsonDocument("$max", "$Projects") }
                 })
                 .ToList();

            return result;           
        }

        public Task UpdateAsync(int id, Knight knight)
        {
            return _collection.ReplaceOneAsync(c => c.KnightId == id, knight);
        }
    }
}
