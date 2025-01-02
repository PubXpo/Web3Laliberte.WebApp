using System;
using System.Collections.Generic;
using System.Linq;
using Web3Laliberte.OperationsAPI.Model;
using Web3Laliberte.OperationsAPI.ViewModel.ContactLog;

namespace Web3Laliberte.OperationsAPI.Utility.Mappers
{
    public static class ContactLogMapper
    {
         public static ContactLogViewModel ToViewModel(ContactLog model)
             {
                 return new ContactLogViewModel
                 {
                     Id = model.Id,
                     Name = model.Name,
                     Email = model.Email,
                     Subject = model.Subject,
                     Message = model.Message,
                     CreatedAt = model.CreatedAt
                 };
             }
            
        public static ContactLog ToModel(ContactLogViewModel viewModel)
        {
            return new ContactLog
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Email = viewModel.Email,
                Subject = viewModel.Subject,
                Message = viewModel.Message,
                CreatedAt = DateTime.UtcNow
            };
        }
        
        public static IEnumerable<ContactLogViewModel> ToViewModelList(IEnumerable<ContactLog> models)
        {
            return models.Select(ToViewModel).ToList();
        }
    }
}