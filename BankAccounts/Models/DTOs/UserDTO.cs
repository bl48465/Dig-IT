namespace BankAccounts.Models.DTOs;

public class UserDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }   
    public string Token { get; set; }
    public List<TransactionDTO> Transactions { get; set; }
}
