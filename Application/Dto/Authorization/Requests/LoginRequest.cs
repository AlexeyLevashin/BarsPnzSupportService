using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Dto.Authorization.Requests;

public class LoginRequest
{
    [Required(ErrorMessage = "Email не может быть пустым")]
    [EmailAddress(ErrorMessage = "Неверный формат email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Пароль не может быть пустым")]
    public string Password { get; set; }
}