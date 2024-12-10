namespace MagicVilla.Web.Models.Dto.User;

public class RegistrationRequestDto
{
    public string UserName { get; set; }
    
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public string Role { get; set; }
}