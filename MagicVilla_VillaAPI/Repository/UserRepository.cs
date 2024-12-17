using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto.Users;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MagicVilla_VillaAPI.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private string _secretKey;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
    }

    public bool IsUniqueUser(string username)
    {
        var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == username);

        if (user == null)
        {
            return true;
        }

        return false;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

        bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
        

        if (user == null || isValid == false)
        {
            return new LoginResponseDto()
            {
                Token = "",
                User = null
            };
        }
        
        // generate jwt if user was found
        var roles = await _userManager.GetRolesAsync(user);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        LoginResponseDto loginResponseDto = new LoginResponseDto()
        {
            Token = tokenHandler.WriteToken(token),
            User = _mapper.Map<UserDto>(user),
        };
        return loginResponseDto;
    }

    public async Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
    {
        ApplicationUser user = new ApplicationUser()
        {
            UserName = registrationRequestDto.Username,
            Email = registrationRequestDto.Username,
            NormalizedEmail = registrationRequestDto.Username.ToUpper(),
            Name = registrationRequestDto.Name,
        };
        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
            if (result.Succeeded)
            {
                if(!_roleManager.RoleExistsAsync(registrationRequestDto.Role).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(registrationRequestDto.Role));
                }
                await _userManager.AddToRoleAsync(user, registrationRequestDto.Role);
                var userToReturn = _db.ApplicationUsers
                    .FirstOrDefault(u => u.UserName == registrationRequestDto.Username);
                return _mapper.Map<UserDto>(userToReturn);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new UserDto();
    }
}