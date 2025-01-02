using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web3Laliberte.OperationsAPI.ViewModel;
using Web3Laliberte.OperationsAPI.ViewModel.Orders;

namespace Web3Laliberte.OperationsAPI.Service.Orders
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionViewModel>> GetAllAsync();
        Task<TransactionViewModel> GetByIdAsync(Guid id);
        Task<List<GiftViewModel>> GetGiftsByBandIdAsync(int bandId);
        Task AddAsync(TransactionViewModel transaction);
        Task UpdateAsync(TransactionViewModel transaction);
        Task<bool> UpdateGiftInventoryAmountAsync(Guid giftId, int inventoryAmount);
        Task DeleteAsync(Guid id);
    }
}