using System.Collections.Generic;
using System.Threading.Tasks;
using Web3Laliberte.OperationsAPI.Models;
using Web3Laliberte.OperationsAPI.Repositories;

namespace Web3Laliberte.OperationsAPI.Services
{
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _repository;

        public FAQService(IFAQRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FAQ>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FAQ> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(FAQ faq)
        {
            await _repository.AddAsync(faq);
        }

        public async Task UpdateAsync(FAQ faq)
        {
            await _repository.UpdateAsync(faq);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}