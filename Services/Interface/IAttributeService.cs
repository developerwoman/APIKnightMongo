using MongoDB.Bson;

namespace APIKnightMongo.Services.Interface
{
    public interface IAttributeService
    {
        Task<List<Entities.Attribute>> GetAllAsync();
        Task<Entities.Attribute> GetByIdAsync(string id);
        Task<Entities.Attribute> CreateAsync(Entities.Attribute attr);       
        Task UpdateAsync(string id, Entities.Attribute attr);
        Task DeleteAsync(string id);       
    }
}
