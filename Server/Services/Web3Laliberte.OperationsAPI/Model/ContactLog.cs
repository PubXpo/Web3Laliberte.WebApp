using System;
using System.ComponentModel.DataAnnotations;

namespace Web3Laliberte.OperationsAPI.Model
{
    public class ContactLog
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}