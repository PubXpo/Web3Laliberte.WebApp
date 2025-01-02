using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web3Laliberte.OperationsAPI.Repository.ContactLog;
using Web3Laliberte.OperationsAPI.ViewModel.ContactLog;
using Web3Laliberte.OperationsAPI.Utility.Mappers;

namespace Web3Laliberte.OperationsAPI.Service.ContactLog
{
    public class ContactLogService : IContactLogService
    {
        private readonly IContactLogRepository _repository;

        public ContactLogService(IContactLogRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(ContactLogViewModel viewModel)
        {
            var contactLog = ContactLogMapper.ToModel(viewModel);
            await _repository.AddAsync(contactLog);
        }

        public async Task<ContactLogViewModel> GetByIdAsync(Guid id)
        {
            var contactLog = await _repository.GetByIdAsync(id);
            return ContactLogMapper.ToViewModel(contactLog);
        }

        public async Task UpdateAsync(ContactLogViewModel viewModel)
        {
            var contactLog = ContactLogMapper.ToModel(viewModel);
            await _repository.UpdateAsync(contactLog);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ContactLogViewModel>> GetAllAsync()
        {
            var contactLogs = await _repository.GetAllAsync();
            return ContactLogMapper.ToViewModelList(contactLogs);
        }
    }
}