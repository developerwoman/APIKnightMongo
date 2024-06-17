
namespace APIKnightMongo.Repositories.Interfaces
{
    public interface IAttributeRepository 
    {
        Task<List<Entities.Attribute>> GetAllAsync();
        Task<Entities.Attribute> GetByIdAsync(int id);
        Task<Entities.Attribute> CreateAsync(Entities.Attribute attr);
        Task DeleteAsync(int id);      
        Task UpdateAsync(int id, Entities.Attribute attr);
    }
}
