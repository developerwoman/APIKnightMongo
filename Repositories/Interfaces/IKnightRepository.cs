using APIKnightMongo.Entities;
using MongoDB.Bson;

namespace APIKnightMongo.Repositories.Interfaces
{
    public interface IKnightRepository
    {
        Task<List<Knight>> GetAllAsync();
        Task<Knight> GetByIdAsync(string id);
        Task<Knight> CreateAsync(Knight knight);        
        Task DeleteAsync(string id);      
        Task UpdateAsync(string id, Knight knight);
        List<BsonDocument> GetWeaponsByKnightIdAsync(string knightId);

    }
}
