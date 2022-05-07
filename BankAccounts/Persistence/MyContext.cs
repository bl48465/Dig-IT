using BankAccounts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Persistence;

public class MyContext : IdentityDbContext
{
    public MyContext(DbContextOptions options) : base(options) { }

    public DbSet<User> AppUsers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasMany(t => t.Transactions)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId);

        builder.Entity<User>()
            .Property(p => p.Balance)
            .HasColumnType("decimal(18,4)");

        builder.Entity<Transaction>()
         .Property(p => p.Amount)
         .HasColumnType("decimal(18,4)");
    }
}
