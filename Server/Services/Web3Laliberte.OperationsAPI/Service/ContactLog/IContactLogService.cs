using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web3Laliberte.OperationsAPI.ViewModel.ContactLog;

namespace Web3Laliberte.OperationsAPI.Service.ContactLog;

public interface IContactLogService
{
    Task<IEnumerable<ContactLogViewModel>> GetAllAsync();
    Task<ContactLogViewModel> GetByIdAsync(Guid id);
    Task AddAsync(ContactLogViewModel viewModel);
    Task UpdateAsync(ContactLogViewModel viewModel);
    Task DeleteAsync(Guid id);
}