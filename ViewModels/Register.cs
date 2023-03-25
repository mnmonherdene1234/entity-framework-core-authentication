using System.ComponentModel.DataAnnotations;

namespace AuthenticationVideoOne.ViewModels;

public class Register
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password not match!")]
    public string? ConfirmPassword { get; set; }
}