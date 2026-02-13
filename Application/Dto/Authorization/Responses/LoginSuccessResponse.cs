namespace Application.Dto.Authorization.Responses;

public class LoginSuccessResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}