using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto.Users;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
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

    public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        throw new NotImplementedException();
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