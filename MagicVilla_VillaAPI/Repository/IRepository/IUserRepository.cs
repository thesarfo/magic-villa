using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto.Users;

namespace MagicVilla_VillaAPI.Repository.IRepository;

public interface IUserRepository
{
    bool IsUniqueUser(string username);

    Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

    Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
}