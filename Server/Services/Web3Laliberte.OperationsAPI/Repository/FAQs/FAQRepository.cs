// Repositories/FAQRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web3Laliberte.OperationsAPI.Data;
using Web3Laliberte.OperationsAPI.Models;

namespace Web3Laliberte.OperationsAPI.Repositories
{
    public class FAQRepository : IFAQRepository
    {
        private readonly ApplicationDbContext _context;

        public FAQRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FAQ>> GetAllAsync()
        {
            return await _context.FAQs.ToListAsync();
        }

        public async Task<FAQ> GetByIdAsync(int id)
        {
            return await _context.FAQs.FindAsync(id);
        }

        public async Task AddAsync(FAQ faq)
        {
            await _context.FAQs.AddAsync(faq);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FAQ faq)
        {
            _context.FAQs.Update(faq);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var faq = await _context.FAQs.FindAsync(id);
            if (faq != null)
            {
                _context.FAQs.Remove(faq);
                await _context.SaveChangesAsync();
            }
        }
    }
}