using System;

namespace Web3Laliberte.OperationsAPI.Model.Orders
{
    public class Transaction
    {
        // Transaction details
        public Guid TransactionId { get; set; }
        public int BandId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; } = "Pending";

        // User and billing details
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string EmailUpdates { get; set; } ="yes";

        public Band Band { get; set; }
    }
}