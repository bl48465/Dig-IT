using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models.DTOs;

public class LoginDTO
{
    [Required]
    [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid!")]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
