
using MongoDB.Bson;

namespace APIKnightMongo.Repositories.Interfaces
{
    public interface IAttributeRepository 
    {
        Task<List<Entities.Attribute>> GetAllAsync();
        Task<Entities.Attribute> GetByIdAsync(string id);
        Task<Entities.Attribute> CreateAsync(Entities.Attribute attr);
        Task DeleteAsync(string id);      
        Task UpdateAsync(string id, Entities.Attribute attr);
    }
}
