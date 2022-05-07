using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models.DTOs;

public class TransactionDTO
{
    [Required]
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}
