using APIKnightMongo.Models;
using APIKnightMongo.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIKnightMongo.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly IMongoCollection<Entities.Attribute> _collection;
        private readonly DbConfiguration _settings;
        
        public AttributeRepository(IMongoDatabase mongoDatabase)
        {

            //_settings = settings.Value;
            //var client = new MongoClient(_settings.ConnectionString);
            //var database = client.GetDatabase(_settings.DatabaseName);
            //_collection = database.GetCollection<Entities.Attribute>(_settings.CollectionName);
            _collection = mongoDatabase.GetCollection<Entities.Attribute>("knight");
        }

        public async Task<Entities.Attribute> CreateAsync(Entities.Attribute attr)
        {
            await _collection.InsertOneAsync(attr).ConfigureAwait(false);
            return attr;
        }

        public Task DeleteAsync(int id)
        {
            return _collection.DeleteOneAsync(c => c.AttributeId == id);
        }

        public async Task<List<Entities.Attribute>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }

        public async Task<Entities.Attribute> GetByIdAsync(int id)
        {
            return await _collection.Find(c => c.AttributeId == id).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(int id, Entities.Attribute attr)
        {
            return _collection.ReplaceOneAsync(c => c.AttributeId == id, attr);
        }
    }
}
