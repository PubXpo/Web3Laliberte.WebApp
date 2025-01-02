using System;
using System.Collections.Generic;
using System.Linq;
using Web3Laliberte.OperationsAPI.Model.Orders;
using Web3Laliberte.OperationsAPI.ViewModel;
using Web3Laliberte.OperationsAPI.ViewModel.Orders;

namespace Web3Laliberte.OperationsAPI.Utility.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionViewModel ToViewModel(Transaction model)
        {
            return new TransactionViewModel
            {
                TransactionId = model.TransactionId,
                BandId = model.BandId,
                Amount = model.Amount,
                Date = model.Date,
                PaymentMethod = model.PaymentMethod,
                Status = model.Status,
                Title = model.Title,
                FirstName = model.FirstName,
                Surname = model.Surname,
                Email = model.Email,
                Postcode = model.Postcode,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                EmailUpdates = model.EmailUpdates,
                Gifts = model.Band.Gifts.Select(g => new GiftViewModel
                {
                    GiftId = g.GiftId,
                    Name = g.Name,
                    Description = g.Description,
                    InventoryAmount = g.InventoryAmount
                }).ToList()
            };
        }

        public static Transaction ToModel(TransactionViewModel viewModel)
        {
            return new Transaction
            {
                TransactionId = Guid.NewGuid(),
                BandId = viewModel.BandId,
                Amount = viewModel.Amount,
                Date = viewModel.Date,
                PaymentMethod = viewModel.PaymentMethod,
                Status = viewModel.Status,
                Title = viewModel.Title,
                FirstName = viewModel.FirstName,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                Postcode = viewModel.Postcode,
                AddressLine1 = viewModel.AddressLine1,
                AddressLine2 = viewModel.AddressLine2,
                City = viewModel.City,
                EmailUpdates = viewModel.EmailUpdates
            };
        }

        public static IEnumerable<TransactionViewModel> ToViewModelList(IEnumerable<Transaction> models)
        {
            return models.Select(ToViewModel).ToList();
        }
    }
}