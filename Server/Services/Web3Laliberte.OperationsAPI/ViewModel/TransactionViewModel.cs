using System;
using System.Collections.Generic;
using Web3Laliberte.OperationsAPI.Model.Orders;

namespace Web3Laliberte.OperationsAPI.ViewModel.Orders
{
    public class TransactionViewModel
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public int BandId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public required string PaymentMethod { get; set; }
        public string Status { get; set; } = "Pending";

        // User and billing details
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Postcode { get; set; }
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string EmailUpdates { get; set; }
        
        // List of gifts in the transaction
        public List<GiftViewModel> Gifts { get; set; } = new List<GiftViewModel>();
    }
}