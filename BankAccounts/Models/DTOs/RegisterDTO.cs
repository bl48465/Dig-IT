using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models.DTOs;

public class RegisterDTO
{
    [Required]
    [MinLength(4, ErrorMessage = "Name must have at least 4 characters!")]
    public string Name { get; set; }

    [Required]
    [MinLength(4, ErrorMessage = "Last Name must have at least 4 characters!")]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid!")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
