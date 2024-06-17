using APIKnightMongo.Entities;

namespace APIKnightMongo.Services.Interface
{
    public interface IKnightService
    {
        Task<List<Knight>> GetAll();
        Task<Knight> GetById(int id);        
        Task<Knight> Create(Knight knight);
        Task<List<Weapon>> GetWeaponsByKnightId(int knightId);
        Task UpdateAsync(int id, Knight knight);
        Task DeleteAsync(int id);
    }
}
