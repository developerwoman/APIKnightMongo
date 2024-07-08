using APIKnightMongo.Entities;

namespace APIKnightMongo.Services.Interface
{
    public interface IKnightService
    {
        Task<List<Knight>> GetAll();
        Task<Knight> GetById(string id);        
        Task<Knight> Create(Knight knight);
        Task<List<Weapon>> GetWeaponsByKnightId(string knightId);
        Task UpdateAsync(string id, Knight knight);
        Task DeleteAsync(string id);
    }
}
