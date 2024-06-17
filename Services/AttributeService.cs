using APIKnightMongo.Repositories.Interfaces;
using APIKnightMongo.Services.Interface;
using MongoDB.Driver;

namespace APIKnightMongo.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attrRepository;
        public AttributeService(IAttributeRepository attrRepository)
        {
            _attrRepository = attrRepository;
        }

        public async Task<Entities.Attribute> CreateAsync(Entities.Attribute attr)
        {
           return await _attrRepository.CreateAsync(attr);
        }

        public async Task DeleteAsync(int id)
        {
            await _attrRepository.DeleteAsync(id);
        }

        public async Task<List<Entities.Attribute>> GetAllAsync()
        {
            return await _attrRepository.GetAllAsync();
        }

        public async Task<Entities.Attribute> GetByIdAsync(int id)
        {
            return await _attrRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Entities.Attribute attr)
        {
            await _attrRepository.UpdateAsync(id, attr);
        }
    }
}
