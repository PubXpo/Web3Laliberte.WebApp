using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web3Laliberte.OperationsAPI.Data;

namespace Web3Laliberte.OperationsAPI.Repository.ContactLog;

public class ContactLogRepository : IContactLogRepository
{
    private readonly ApplicationDbContext _context;

    public ContactLogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Model.ContactLog>> GetAllAsync()
    {
        return await _context.ContactLogs.ToListAsync();
    }

    public async Task<Model.ContactLog> GetByIdAsync(Guid id)
    {
        return await _context.ContactLogs.FindAsync(id);
    }

    public async Task AddAsync(Model.ContactLog contactLog)
    {
        await _context.ContactLogs.AddAsync(contactLog);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.ContactLog contactLog)
    {
        _context.ContactLogs.Update(contactLog);
        await _context.SaveChangesAsync();
    }
    

    public async Task DeleteAsync(Guid id)
    {
        var contactLog = await _context.ContactLogs.FindAsync(id);
        if (contactLog != null)
        {
            _context.ContactLogs.Remove(contactLog);
            await _context.SaveChangesAsync();
        }
    }
}