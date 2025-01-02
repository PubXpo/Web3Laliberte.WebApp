using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web3Laliberte.OperationsAPI.Data;
using Web3Laliberte.OperationsAPI.Model.Orders;
using Web3Laliberte.OperationsAPI.ViewModel.Orders;
using Microsoft.EntityFrameworkCore;
using Web3Laliberte.OperationsAPI.ViewModel;

namespace Web3Laliberte.OperationsAPI.Service.Orders
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionViewModel>> GetAllAsync()
        {
            return await _context.Transactions
                .Include(t => t.Band)
                .ThenInclude(b => b.Gifts)
                .Select(t => new TransactionViewModel
                {
                    TransactionId = t.TransactionId,
                    BandId = t.BandId,
                    Amount = t.Amount,
                    Date = t.Date,
                    PaymentMethod = t.PaymentMethod,
                    Status = t.Status,
                    Title = t.Title,
                    FirstName = t.FirstName,
                    Surname = t.Surname,
                    Email = t.Email,
                    Postcode = t.Postcode,
                    AddressLine1 = t.AddressLine1,
                    AddressLine2 = t.AddressLine2,
                    City = t.City,
                    EmailUpdates = t.EmailUpdates,
                    Gifts = _context.Bands
                        .Where(b => b.BandId <= t.BandId)
                        .SelectMany(b => b.Gifts)
                        .Select(g => new GiftViewModel
                        {
                            GiftId = g.GiftId,
                            Name = g.Name,
                            Description = g.Description,
                            InventoryAmount = g.InventoryAmount
                        }).ToList()
                })
                .ToListAsync();
            
        }

        public async Task<TransactionViewModel> GetByIdAsync(Guid id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Band)
                .ThenInclude(b => b.Gifts)
                .FirstOrDefaultAsync(t => t.TransactionId == id);

            if (transaction == null) return null;

            return new TransactionViewModel
            {
                TransactionId = transaction.TransactionId,
                BandId = transaction.BandId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                PaymentMethod = transaction.PaymentMethod,
                Status = transaction.Status,
                Title = transaction.Title,
                FirstName = transaction.FirstName,
                Surname = transaction.Surname,
                Email = transaction.Email,
                Postcode = transaction.Postcode,
                AddressLine1 = transaction.AddressLine1,
                AddressLine2 = transaction.AddressLine2,
                City = transaction.City,
                EmailUpdates = transaction.EmailUpdates,
                Gifts = _context.Bands
                    .Where(b => b.BandId <= transaction.BandId)
                    .SelectMany(b => b.Gifts)
                    .Select(g => new GiftViewModel
                    {
                        GiftId = g.GiftId,
                        Name = g.Name,
                        Description = g.Description,
                        InventoryAmount = g.InventoryAmount
                    }).ToList()
            };
        }
        
        public async Task<List<GiftViewModel>> GetGiftsByBandIdAsync(int bandId)
        {
            return await _context.Bands
                .Where(b => b.BandId == bandId)
                .SelectMany(b => b.Gifts)
                .Select(g => new GiftViewModel
                {
                    GiftId = g.GiftId,
                    Name = g.Name,
                    Description = g.Description,
                    InventoryAmount = g.InventoryAmount
                }).ToListAsync();
        }

        public async Task AddAsync(TransactionViewModel transaction)
        {
            var newTransaction = new Transaction
            {
                TransactionId = transaction.TransactionId,
                BandId = transaction.BandId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                PaymentMethod = transaction.PaymentMethod,
                Status = "Pending",
                Title = transaction.Title,
                FirstName = transaction.FirstName,
                Surname = transaction.Surname,
                Email = transaction.Email,
                Postcode = transaction.Postcode,
                AddressLine1 = transaction.AddressLine1,
                AddressLine2 = transaction.AddressLine2,
                City = transaction.City,
                EmailUpdates = transaction.EmailUpdates
            };

            _context.Transactions.Add(newTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransactionViewModel transaction)
        {
            var existingTransaction = await _context.Transactions.FindAsync(transaction.TransactionId);
            if (existingTransaction == null) return;

            existingTransaction.BandId = transaction.BandId;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Date = transaction.Date;
            existingTransaction.PaymentMethod = transaction.PaymentMethod;
            existingTransaction.Status = transaction.Status;
            existingTransaction.Title = transaction.Title;
            existingTransaction.FirstName = transaction.FirstName;
            existingTransaction.Surname = transaction.Surname;
            existingTransaction.Email = transaction.Email;
            existingTransaction.Postcode = transaction.Postcode;
            existingTransaction.AddressLine1 = transaction.AddressLine1;
            existingTransaction.AddressLine2 = transaction.AddressLine2;
            existingTransaction.City = transaction.City;
            existingTransaction.EmailUpdates = transaction.EmailUpdates;

            _context.Transactions.Update(existingTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateGiftInventoryAmountAsync(Guid giftId, int inventoryAmount)
        {
            var gift = await _context.Gifts.FirstOrDefaultAsync(g => g.GiftId == giftId);
            if (gift == null) return false;

            gift.InventoryAmount = inventoryAmount;
            _context.Gifts.Update(gift);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task DeleteAsync(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return;

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}