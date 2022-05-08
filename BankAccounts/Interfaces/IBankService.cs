using BankAccounts.Models;


namespace BankAccounts.Interfaces;

public interface IBankService
{
    Task<Transaction> Deposit(decimal amount);
    Task<Transaction> Withdraw(decimal amount);
    Task<decimal> CurrentBalance(string userId);
}
