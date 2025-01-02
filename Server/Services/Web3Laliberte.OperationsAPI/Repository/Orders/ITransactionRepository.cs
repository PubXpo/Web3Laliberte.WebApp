using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web3Laliberte.OperationsAPI.Model.Orders;

namespace Web3Laliberte.OperationsAPI.Repository.Orders
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction> GetByIdAsync(Guid id);
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(Guid id);
    }
}