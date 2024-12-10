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
        throw new NotImplementedException();
    }

    public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto)
    {
        throw new NotImplementedException();
    }
}