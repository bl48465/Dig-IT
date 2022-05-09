using System.Threading.Tasks;
using BankAccounts.Models;

namespace BankAccounts.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}
