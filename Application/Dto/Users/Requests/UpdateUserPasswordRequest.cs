using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Users.Requests;

public class UpdateUserPasswordRequest
{
    [Required (ErrorMessage = "Пароль обязателен для заполнения")]
    [MinLength(6, ErrorMessage = "Длина пароля должна быть не меньше 6 символов")]
    public string Password { get; set; }
    
    [Required (ErrorMessage = "Пароль обязателен для заполнения")]
    [MinLength(6, ErrorMessage = "Длина пароля должна быть не меньше 6 символов")]
    public string NewPassword { get; set; }
    
    [Required(ErrorMessage = "Подтверждение пароля обязательно")]
    [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")] 
    public string ConfirmNewPassword { get; set; }
}