namespace MagicVilla_VillaAPI.Models.Dto.Users;

public class LoginResponseDto
{
    public LocalUser User { get; set; }
    
    public string Token { get; set; }
}