using BankAccounts.Interfaces;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;

namespace BankAccounts.Services;

public class BankService : IBankService
{

    private readonly UserManager<User> _userManager;

    public BankService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public Task<decimal> CurrentBalance(string userId)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
        //if (user != null) { return user.Balance; }
        //else { return null }

    }

    public Task<Transaction> Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> Withdraw(decimal amount)
    {
        throw new NotImplementedException();
    }
}
