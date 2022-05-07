﻿using Microsoft.AspNetCore.Identity;

namespace BankAccounts.Models;

public class User : IdentityUser
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public decimal Balance { get; set; }
    public List<Transaction> Transactions { get; set; }
}
