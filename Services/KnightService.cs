using APIKnightMongo.Entities;
using APIKnightMongo.Repositories.Interfaces;
using APIKnightMongo.Services.Interface;
using MongoDB.Bson;

namespace APIKnightMongo.Services
{
    public class KnightService : IKnightService
    {
        private readonly IKnightRepository _knightRepository;

        public KnightService(IKnightRepository knightRepository)
        {
            _knightRepository = knightRepository;
        }

        public async Task<Knight> Create(Knight knight)
        {
            return await _knightRepository.CreateAsync(knight);
        }

        public Task DeleteAsync(int id)
        {
            return _knightRepository.DeleteAsync(id);
        }
        public async Task<List<Knight>> GetAll()
        {
            return await _knightRepository.GetAllAsync();
        }

        public async Task<Knight> GetById(int id)
        {
            return await _knightRepository.GetByIdAsync(id);
        }

        public List<BsonDocument> GetWeaponsByKnightId(int knightId)
        {
            return _knightRepository.GetWeaponsByKnightIdAsync(knightId);
        }

        public Task UpdateAsync(int id, Knight knight)
        {
            return _knightRepository.UpdateAsync(id, knight);
        }

        Task<List<Weapon>> IKnightService.GetWeaponsByKnightId(int knightId)
        {
            throw new NotImplementedException();
        }
    }
}
