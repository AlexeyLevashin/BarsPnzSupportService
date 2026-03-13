using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Authorization.Requests;

public class RefreshRequest
{
    [Required (ErrorMessage = "Токен не может быть пустым")]
    public string RefreshToken { get; set; }
}