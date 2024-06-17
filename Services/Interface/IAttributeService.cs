namespace APIKnightMongo.Services.Interface
{
    public interface IAttributeService
    {
        Task<List<Entities.Attribute>> GetAllAsync();
        Task<Entities.Attribute> GetByIdAsync(int id);
        Task<Entities.Attribute> CreateAsync(Entities.Attribute attr);       
        Task UpdateAsync(int id, Entities.Attribute attr);
        Task DeleteAsync(int id);       
    }
}
