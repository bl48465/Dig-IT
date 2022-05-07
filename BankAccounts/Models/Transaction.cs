namespace BankAccounts.Models;

public class Transaction
{
    public int TransactionId { get; set; }

    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
}
