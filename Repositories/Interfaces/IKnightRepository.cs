using APIKnightMongo.Entities;
using MongoDB.Bson;

namespace APIKnightMongo.Repositories.Interfaces
{
    public interface IKnightRepository
    {
        Task<List<Knight>> GetAllAsync();
        Task<Knight> GetByIdAsync(int id);
        Task<Knight> CreateAsync(Knight knight);        
        Task DeleteAsync(int id);      
        Task UpdateAsync(int id, Knight knight);
        List<BsonDocument> GetWeaponsByKnightIdAsync(int knightId);

    }
}
