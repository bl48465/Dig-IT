using BankAccounts.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Persistence;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);

    //    builder.Entity<User>()
    //        .HasMany(t => t.Transactions)
    //        .WithOne(u => u.User)
    //        .HasForeignKey(u => u.UserId);

    //    builder.Entity<Transaction>()
    //        .HasOne(u => u.User)
    //        .WithMany(t => t.Transactions)
    //        .HasForeignKey(x => x.TransactionId);
    //}
}
