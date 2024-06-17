using APIKnightMongo.Models;
using APIKnightMongo.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace APIKnightMongo.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly IMongoCollection<Entities.Attribute> _collection;
        private readonly DbConfiguration _settings;

        public AttributeRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<Entities.Attribute>("knight");
        }

        public async Task<Entities.Attribute> CreateAsync(Entities.Attribute attr)
        {
            await _collection.InsertOneAsync(attr).ConfigureAwait(false);
            return attr;
        }

        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c._id == id);
        }

        public async Task<List<Entities.Attribute>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }

        public async Task<Entities.Attribute> GetByIdAsync(string id)
        {
            return await _collection.Find(c => c._id == id).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(string id, Entities.Attribute attr)
        {
            var filter = Builders<Entities.Attribute>.Filter.Eq(c => c._id, id);

            return _collection.ReplaceOneAsync(filter, attr);
        }
    }
}
