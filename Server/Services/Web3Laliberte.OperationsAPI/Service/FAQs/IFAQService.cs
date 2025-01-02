using System.Collections.Generic;
using System.Threading.Tasks;
using Web3Laliberte.OperationsAPI.Models;

namespace Web3Laliberte.OperationsAPI.Services
{
    public interface IFAQService
    {
        Task<IEnumerable<FAQ>> GetAllAsync();
        Task<FAQ> GetByIdAsync(int id);
        Task AddAsync(FAQ faq);
        Task UpdateAsync(FAQ faq);
        Task DeleteAsync(int id);
    }
}