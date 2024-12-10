namespace MagicVilla.Web.Models.Dto.User;

public class LoginResponseDto
{
    public UserDto User { get; set; }
    
    public string Token { get; set; }
}