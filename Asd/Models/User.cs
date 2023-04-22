using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Asd.Models;

public class User : IdentityUser
{
    
}

public class CreationUser
{
    [Required(ErrorMessage = "Поле не введено")]
    [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
    public string Email { get; set; }
    
    [Required]
    [MinLength(3)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [MinLength(3)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }
}