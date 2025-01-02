using System;
using System.ComponentModel.DataAnnotations;

namespace Web3Laliberte.OperationsAPI.ViewModel.ContactLog
{
    public class ContactLogViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; } 
        public string Message { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
    }
}