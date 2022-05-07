using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models.DTOs;

public class LoginDTO
{
    [Required]
    [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid!")]
    public string Email { get; set; }

    [Required]
    [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$",ErrorMessage = "Password doesn't meet the requirements!")]
    public string Password { get; set; }
}
