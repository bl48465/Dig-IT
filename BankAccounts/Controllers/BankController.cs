using BankAccounts.Models;
using BankAccounts.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace BankAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MyContext _db;

        public BankController(UserManager<User> userManager,MyContext db)
        {
            _userManager = userManager;
            _db = db;   
        }

        [HttpPost("deposit")]
        public async Task<ActionResult<string>> Deposit(decimal amount)
        {
            var user = await _userManager.FindByIdAsync("f74f7635-f2ef-4f3d-99fa-ce3948555f3a");

            if (amount <= 0) { return BadRequest($"You can't deposit {amount} $ in your account"); }

            //Database will not allow another transaction with the same ID.

            Transaction newTransaction = new Transaction
            {
                Amount = amount,
                CreatedAt = DateTime.Now,
                UserId = user.Id
            };

            user.Balance += amount;
            _db.Transactions.Add(newTransaction);
            _db.SaveChanges();
            

            await _userManager.UpdateAsync(user);

            return Ok($"Transaction successful : Transaction ID: {newTransaction.TransactionId},  Amount: {newTransaction.Amount} $, Date: {newTransaction.CreatedAt}");
        }

        [HttpPost("withdraw")]
        public async Task<ActionResult<string>> Withdraw(decimal amount)
        {
            var user = await _userManager.FindByIdAsync("f74f7635-f2ef-4f3d-99fa-ce3948555f3a");

            if (amount <= 0) { return BadRequest($"You can't withdraw {amount} $ in your account"); }
            if (amount > user.Balance) { return BadRequest("You have suffiecient funds in your account"); }

            //Database will not allow another transaction with the same ID.

            Transaction newTransaction = new Transaction
            {
                Amount = -amount,
                CreatedAt = DateTime.Now,
                UserId = user.Id
            };

            user.Balance -= amount;
            _db.Transactions.Add(newTransaction);
            _db.SaveChanges();


            await _userManager.UpdateAsync(user);

            return Ok($"Transaction successful : Transaction ID: {newTransaction.TransactionId},  Amount: {newTransaction.Amount} $, Date: {newTransaction.CreatedAt}");
        }

        [HttpGet("balance")]
        public async Task<ActionResult<string>> CurrentBalance()
        {
            var user = await _userManager.FindByIdAsync("f74f7635-f2ef-4f3d-99fa-ce3948555f3a");

            if(user !=null)
            return Ok($"Your balance is {user.Balance} $");
            else
            {
                return NotFound("User not found");
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<string>> History()
        {
            var user = await _userManager.FindByIdAsync("f74f7635-f2ef-4f3d-99fa-ce3948555f3a");
            var userTransactions = _db.Transactions.Where(x => x.UserId.Equals(user.Id));
            var history = new StringBuilder();

            history.AppendLine("Amount\t\tDate");
            foreach(var transaction in userTransactions)
            {
                history.AppendLine($"{transaction.Amount}\t{transaction.CreatedAt}");
            }

            if (user != null)
                return Ok($"Your account history: {history.ToString()}");
            else
            {
                return NotFound("User not found");
            }
        }
    }
}
