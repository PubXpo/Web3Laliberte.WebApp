using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web3Laliberte.OperationsAPI.Repository.ContactLog
{
    public interface IContactLogRepository
    {
        Task<IEnumerable<Model.ContactLog>> GetAllAsync();
        Task<Model.ContactLog> GetByIdAsync(Guid id);
        Task AddAsync(Model.ContactLog contactLog);
        Task UpdateAsync(Model.ContactLog contactLog);
        Task DeleteAsync(Guid id);
    }
}