namespace MagicVilla_VillaAPI.Models.Dto.Users;

public class RegistrationRequestDto
{
    public string Username { get; set; }
    
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public string Role { get; set; }
}