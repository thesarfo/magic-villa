using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto.Users;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;

namespace MagicVilla_VillaAPI.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    private string _secretKey;

    public UserRepository(ApplicationDbContext db, IConfiguration configuration)
    {
        _db = db;
        _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
    }

    public bool IsUniqueUser(string username)
    {
        var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);

        if (user == null)
        {
            return true;
        }

        return false;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var user = _db.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower()
        && u.Password == loginRequestDto.Password);

        if (user == null)
        {
            return null;
        }
        
        // generate jwt if user was found
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        LoginResponseDto loginResponseDto = new LoginResponseDto()
        {
            Token = tokenHandler.WriteToken(token),
            User = user
        };
        return loginResponseDto;
    }

    public async Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto)
    {
        LocalUser user = new LocalUser()
        {
            UserName = registrationRequestDto.Username,
            Name = registrationRequestDto.Name,
            Password = registrationRequestDto.Password,
            Role = registrationRequestDto.Role
        };
        await _db.LocalUsers.AddAsync(user);
        await _db.SaveChangesAsync();

        user.Password = "";
        return user;
    }
}